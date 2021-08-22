using System.Runtime.InteropServices;


namespace AlephVault.Unity.Binary
{
    namespace Unions
    {
        /// <summary>
        ///   <para>
        ///     A 32-bit float that can be mapped into an uint value.
        ///   </para>
        ///   <para>
        ///     Essentially stolen from MLAPI package.
        ///   </para>
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct Float4
        {
            [FieldOffset(0)]
            public float FloatValue;

            [FieldOffset(0)]
            public uint UIntValue;
        }
    }
}