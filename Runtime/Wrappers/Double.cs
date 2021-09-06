namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="double"/> value.
        /// </summary>
        public class Double : Wrapper<double>
        {
            public Double(double wrapped) : base(wrapped) { }

            public Double() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Double(double value) => new Double(value);
        }
    }
}
