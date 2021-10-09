namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="byte[]"/> value.
        /// </summary>
        public class ByteArray : Wrapper<byte[]>
        {
            public ByteArray(byte[] wrapped) : base(wrapped) { }

            public ByteArray() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator ByteArray(byte[] value) => new ByteArray(value);
        }
    }
}
