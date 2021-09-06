namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="uint"/> value.
        /// </summary>
        public class UInt : Wrapper<uint>
        {
            public UInt(uint wrapped) : base(wrapped) { }

            public UInt() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator UInt(uint value) => new UInt(value);
        }
    }
}
