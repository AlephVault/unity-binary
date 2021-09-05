using AlephVault.Unity.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlephVault.Unity.Binary
{
    namespace Delta
    {
        /// <summary>
        ///   This is a serializable delta over a particular type.
        ///   The delta is meant for individual property synchronization,
        ///   so after serialization it knows how to affect an existing
        ///   property by combining.
        /// </summary>
        /// <typeparam name="T">The wrapped type</typeparam>
        public interface IDelta<T> : ISerializable
        {
            /// <summary>
            ///   Returns a new value that is a combination of a given
            ///   value and the current delta. The combination may be
            ///   an in-place combination for things like collections.
            /// </summary>
            /// <param name="current">The current value to combine</param>
            /// <returns>The new, combined, value</returns>
            public T Combine(T current);
        }
    }
}
