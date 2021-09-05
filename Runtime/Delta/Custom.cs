using AlephVault.Unity.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlephVault.Unity.Binary
{
    namespace Delta
    {
        /// <summary>
        ///   This is a simple delta consisting on a wrapped
        ///   arbitrary type delta. This one just involves
        ///   replacing the old value with the new value.
        /// </summary>
        /// <typeparam name="T">The wrapped type</typeparam>
        public abstract class Custom<T> : IDelta<T>
        {
            /// <summary>
            ///   The actual value serving as replacement.
            /// </summary>
            protected T deltaValue;

            /// <summary>
            ///   Builds a delta, specifying a value.
            ///   Useful for the server side.
            /// </summary>
            /// <param name="newValue">The new value for the delta</param>
            public Custom(T newValue)
            {
                deltaValue = newValue;
            }

            /// <summary>
            ///   Builds a delta, specifying a default value.
            ///   Useful for the client side.
            /// </summary>
            public Custom()
            {
                deltaValue = default(T);
            }

            /// <summary>
            ///   The combination is simply replacement of the old
            ///   value with the new one.
            /// </summary>
            /// <param name="current">The current value to combine</param>
            /// <returns>The new, combined, value</returns>
            public T Combine(T current)
            {
                return deltaValue;
            }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public abstract void Serialize(Serializer serializer);
        }
    }
}
