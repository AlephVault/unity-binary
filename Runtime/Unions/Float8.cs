using System.Runtime.InteropServices;


namespace AlephVault.Unity.Binary
{
    namespace Unions
    {
        /// <summary>
        ///   <para>
        ///     A 64-bit float that can be mapped into an ulong value.
        ///   </para>
        ///   <para>
        ///     Essentially stolen from MLAPI package.
        ///   </para>
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct Float8
        {
            [FieldOffset(0)]
            public double DoubleValue;

            [FieldOffset(0)]
            public ulong ULongValue;
        }
    }
}