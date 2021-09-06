namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="UnityEngine.Color"/> value.
        /// </summary>
        public class Color : Wrapper<UnityEngine.Color>
        {
            public Color(UnityEngine.Color wrapped) : base(wrapped) { }

            public Color() : base() { }

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
