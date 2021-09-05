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
        ///   sbyte delta. This one just involves replacing
        ///   the old value with the new value.
        /// </summary>
        /// <typeparam name="T">The wrapped type</typeparam>
        public class SByte<T> : Custom<sbyte>
        {
            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref deltaValue);
            }
        }
    }
}
