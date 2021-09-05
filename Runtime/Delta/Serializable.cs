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
        ///   serializable delta. This one just involves
        ///   replacing the old serializable with the new
        ///   serializable value.
        /// </summary>
        /// <typeparam name="T">The wrapped type</typeparam>
        public class Serializable<T> : Custom<T> where T : ISerializable, new()
        {
            /// <summary>
            ///   Builds a delta, specifying a value.
            ///   Useful for the server side.
            /// </summary>
            /// <param name="newValue">The new value for the delta</param>
            public Serializable(T newValue)
            {
                deltaValue = newValue;
            }

            /// <summary>
            ///   Builds a delta, specifying a default value.
            ///   Useful for the client side.
            /// </summary>
            public Serializable()
            {
                deltaValue = new T();
            }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                if (serializer.IsReading || EqualityComparer<T>.Default.Equals(default(T), deltaValue))
                {
                    deltaValue = new T();
                }
                deltaValue.Serialize(serializer);
            }
        }
    }
}
