namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="Vector3"/> value.
        /// </summary>
        public class Vector3 : Wrapper<UnityEngine.Vector3>
        {
            public Vector3(UnityEngine.Vector3 wrapped) : base(wrapped) { }

            public Vector3() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Vector3(UnityEngine.Vector3 value) => new Vector3(value);
        }
    }
}
