namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="ushort"/> value.
        /// </summary>
        public class UShort : Wrapper<ushort>
        {
            public UShort(ushort wrapped) : base(wrapped) { }

            public UShort() : base() { }

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
