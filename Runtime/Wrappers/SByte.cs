namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="sbyte"/> value.
        /// </summary>
        public class SByte : Wrapper<sbyte>
        {
            public SByte(sbyte wrapped) : base(wrapped) { }

            public SByte() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator SByte(sbyte value) => new SByte(value);
        }
    }
}
