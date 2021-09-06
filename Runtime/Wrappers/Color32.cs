namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="UnityEngine.Color32"/> value.
        /// </summary>
        public class Color32 : Wrapper<UnityEngine.Color32>
        {
            public Color32(UnityEngine.Color32 wrapped) : base(wrapped) { }

            public Color32() : base() { }

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
