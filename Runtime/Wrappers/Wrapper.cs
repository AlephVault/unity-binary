namespace AlephVault.Unity.Binary
{
    namespace Wrappers
    {
        /// <summary>
        ///   A wrapper around types that are typically not
        ///   serializable.
        /// </summary>
        /// <typeparam name="T">The type to wrap</typeparam>
        public abstract class Wrapper<T> : ISerializable
        {
            /// <summary>
            ///   The wrapped value.
            /// </summary>
            public T Wrapped;

            public Wrapper(T wrapped)
            {
                Wrapped = wrapped;
            }

            public Wrapper()
            {
                Wrapped = default;
            }

            /// <summary>
            ///   Serializes/deserializes the wrapped value.
            /// </summary>
            /// <param name="serializer">The serialuzer to use</param>
            public abstract void Serialize(Serializer serializer);

            /// <summary>
            ///   Allows casting this type to the wrapped type.
            /// </summary>
            /// <param name="wrapper">The wrapper to cast</param>
            public static implicit operator T(Wrapper<T> wrapper)
            {
                return wrapper.Wrapped;
            }
        }
    }
}
