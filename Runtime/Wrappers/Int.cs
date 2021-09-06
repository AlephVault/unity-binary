namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="int"/> value.
        /// </summary>
        public class Int : Wrapper<int>
        {
            public Int(int wrapped) : base(wrapped) { }

            public Int() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Int(int value) => new Int(value);
        }
    }
}
