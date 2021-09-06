namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="Vector4"/> value.
        /// </summary>
        public class Vector4 : Wrapper<UnityEngine.Vector4>
        {
            public Vector4(UnityEngine.Vector4 wrapped) : base(wrapped) { }

            public Vector4() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }
        }
    }
}
