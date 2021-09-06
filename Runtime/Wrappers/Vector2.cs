namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="Vector2"/> value.
        /// </summary>
        public class Vector2 : Wrapper<UnityEngine.Vector2>
        {
            public Vector2(UnityEngine.Vector2 wrapped) : base(wrapped) { }

            public Vector2() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Vector2(UnityEngine.Vector2 value) => new Vector2(value);
        }
    }
}
