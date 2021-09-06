namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="string"/> value.
        /// </summary>
        public class String : Wrapper<string>
        {
            public String(string wrapped) : base(wrapped) { }

            public String() : base() { }

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
