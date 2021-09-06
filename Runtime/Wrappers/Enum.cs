namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="System.Enum"/>-typed value.
        /// </summary>
        public class Enum<T> : Wrapper<T> where T : unmanaged, System.Enum
        {
            public Enum(T wrapped) : base(wrapped) { }

            public Enum() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Enum<T>(T value) => new Enum<T>(value);
        }
    }
}
