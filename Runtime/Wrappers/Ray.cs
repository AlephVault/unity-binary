namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="UnityEngine.Ray"/> value.
        /// </summary>
        public class Ray : Wrapper<UnityEngine.Ray>
        {
            public Ray(UnityEngine.Ray wrapped) : base(wrapped) { }

            public Ray() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Ray(UnityEngine.Ray value) => new Ray(value);
        }
    }
}
