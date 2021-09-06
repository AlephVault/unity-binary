namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="float"/> value.
        /// </summary>
        public class Float : Wrapper<float>
        {
            public Float(float wrapped) : base(wrapped) { }

            public Float() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Float(float value) => new Float(value);
        }
    }
}
