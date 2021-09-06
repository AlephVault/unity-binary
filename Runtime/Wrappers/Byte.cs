namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="byte"/> value.
        /// </summary>
        public class Byte : Wrapper<byte>
        {
            public Byte(byte wrapped) : base(wrapped) { }

            public Byte() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Byte(byte value) => new Byte(value);
        }
    }
}
