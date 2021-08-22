namespace AlephVault.Unity.Binary
{
    /// <summary>
    ///   <para>
    ///     This interface enables bi-directional serialization
    ///     of a class: This means that the implementing class
    ///     must be aware of the context of the serializer
    ///     (essentially, reading or writing) and/or use the
    ///     underlying methods that are aware of it.
    ///   </para>
    ///   <para>
    ///     Essentially stolen from MLAPI package.
    ///   </para>
    /// </summary>
    public interface ISerializable
    {
        void Serialize(Serializer serializer);
    }
}
