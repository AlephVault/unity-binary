namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="bool"/> value.
        /// </summary>
        public class Bool : Wrapper<bool>
        {
            public Bool(bool wrapped) : base(wrapped) {}

            public Bool() : base() {}

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
