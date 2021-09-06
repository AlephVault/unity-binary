namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="long"/> value.
        /// </summary>
        public class Long : Wrapper<long>
        {
            public Long(long wrapped) : base(wrapped) { }

            public Long() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Long(long value) => new Long(value);
        }
    }
}
