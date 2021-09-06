namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="ulong"/> value.
        /// </summary>
        public class ULong : Wrapper<ulong>
        {
            public ULong(ulong wrapped) : base(wrapped) { }

            public ULong() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator ULong(ulong value) => new ULong(value);
        }
    }
}
