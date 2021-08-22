using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlephVault.Unity.Binary
{
    /// <summary>
    ///   <para>
    ///     A pooled buffer knows about its pool and, on disposal,
    ///     it returns to the pool. Otherwise, it is a standard
    ///     buffer.
    ///   </para>
    ///   <para>
    ///     Essentially stolen from MLAPI package.
    ///   </para>
    /// </summary>
    public class PooledBuffer : Buffer, IDisposable
    {
        private static uint s_CreatedBuffers = 0;
        private static Queue<WeakReference> s_OverflowBuffers = new Queue<WeakReference>();
        private static Queue<PooledBuffer> s_Buffers = new Queue<PooledBuffer>();

        private const uint k_MaxBitPoolBuffers = 1024;
        private const uint k_MaxCreatedDelta = 768;

        // Tells whether the current buffer is disposed or in use.
        private bool isDisposed = false;

        /// <summary>
        /// Retrieves an expandable PooledBuffer from the pool
        /// </summary>
        /// <returns>An expandable PooledNetworkBuffer</returns>
        public static PooledBuffer Get()
        {
            if (s_Buffers.Count == 0)
            {
                if (s_OverflowBuffers.Count > 0)
                {
                    Debug.Log($"Retrieving {nameof(PooledBuffer)} from overflow pool. Recent burst?");

                    object weakBuffer = null;
                    while (s_OverflowBuffers.Count > 0 && ((weakBuffer = s_OverflowBuffers.Dequeue().Target) == null));

                    if (weakBuffer != null)
                    {
                        PooledBuffer strongBuffer = (PooledBuffer)weakBuffer;

                        strongBuffer.SetLength(0);
                        strongBuffer.Position = 0;

                        return strongBuffer;
                    }
                }

                if (s_CreatedBuffers == k_MaxBitPoolBuffers)
                {
                    Debug.LogWarning($"{k_MaxBitPoolBuffers} buffers have been created. Did you forget to dispose?");
                }
                else if (s_CreatedBuffers < k_MaxBitPoolBuffers) s_CreatedBuffers++;

                return new PooledBuffer();
            }

            PooledBuffer buffer = s_Buffers.Dequeue();
            buffer.SetLength(0);
            buffer.Position = 0;
            buffer.isDisposed = false;
            return buffer;
        }

        /// <summary>
        ///   Returns the PooledBuffer into the pool.
        /// </summary>
        public new void Dispose()
        {
            if (!isDisposed)
            {
                if (s_Buffers.Count > k_MaxCreatedDelta)
                {
                    // The user just created lots of buffers without returning them in between.
                    // Buffers are essentially byte array wrappers. This is valuable memory.
                    // Thus we put this buffer as a weak reference incase of another burst
                    // But still leave it to GC
                    Debug.Log($"Putting {nameof(PooledBuffer)} into overflow pool. Did you forget to dispose?");

                    s_OverflowBuffers.Enqueue(new WeakReference(this));
                }
                else
                {
                    s_Buffers.Enqueue(this);
                }
            }
        }
    }
}