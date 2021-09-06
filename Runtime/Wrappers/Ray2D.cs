namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A serializable wrapper around a <see cref="UnityEngine.Ray2D"/> value.
        /// </summary>
        public class Ray2D : Wrapper<UnityEngine.Ray2D>
        {
            public Ray2D(UnityEngine.Ray2D wrapped) : base(wrapped) { }

            public Ray2D() : base() { }

            /// <summary>
            ///   The serialization is done by doing it over the internal
            ///   delta value member.
            /// </summary>
            /// <param name="serializer">The serializer to use</param>
            public override void Serialize(Serializer serializer)
            {
                serializer.Serialize(ref Wrapped);
            }

            public static explicit operator Ray2D(UnityEngine.Ray2D value) => new Ray2D(value);
        }
    }
}
