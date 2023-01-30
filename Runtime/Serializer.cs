using System;
using UnityEngine;

namespace AlephVault.Unity.Binary
{
    /// <summary>
    ///   <para>
    ///     A network serializer uses the same methods for
    ///     reading and writing, but the direction those
    ///     methods execute in, depend on whether this
    ///     serializer is instantiated with a network reader
    ///     or with a network writer.
    ///   </para>
    ///   <para>
    ///     Essentially stolen from MLAPI package.
    ///   </para>
    /// </summary>
    public sealed class Serializer
    {
        private readonly Reader m_Reader;
        private readonly Writer m_Writer;

        public Reader Reader => m_Reader;
        public Writer Writer => m_Writer;

        public bool IsReading { get; }

        public Serializer(Reader reader)
        {
            m_Reader = reader;
            IsReading = true;
        }

        public Serializer(Writer writer)
        {
            m_Writer = writer;
            IsReading = false;
        }

        public void Serialize(ref bool value)
        {
            if (IsReading) value = m_Reader.ReadBool();
            else m_Writer.WriteBool(value);
        }

        public void Serialize(ref bool? value)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? m_Reader.ReadBool() : (bool?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue) m_Writer.WriteBool(value.Value);
            }
        }

        public void Serialize(ref char value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadCharPacked() : m_Reader.ReadChar();
            else { if (packed) { m_Writer.WriteCharPacked(value); } else { m_Writer.WriteChar(value); }}
        }

        public void Serialize(ref char? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadCharPacked() : m_Reader.ReadChar()) : (char?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteCharPacked(value.Value); } else { m_Writer.WriteChar(value.Value); }
                }
            }
        }

        public void Serialize(ref sbyte value)
        {
            if (IsReading) value = m_Reader.ReadSByte();
            else m_Writer.WriteSByte(value);
        }

        public void Serialize(ref sbyte? value)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? m_Reader.ReadSByte() : (sbyte?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue) m_Writer.WriteSByte(value.Value);
            }
        }

        public void Serialize(ref byte value)
        {
            if (IsReading) value = m_Reader.ReadByteDirect();
            else m_Writer.WriteByte(value);
        }

        public void Serialize(ref byte? value)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? m_Reader.ReadByteDirect() : (byte?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue) m_Writer.WriteByte(value.Value);
            }
        }

        public void Serialize(ref short value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadInt16Packed() : m_Reader.ReadInt16();
            else { if (packed) { m_Writer.WriteInt16Packed(value); } else { m_Writer.WriteInt16(value); }}
        }

        public void Serialize(ref short? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadInt16Packed() : m_Reader.ReadInt16()) : (short?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteInt16Packed(value.Value); } else { m_Writer.WriteInt16(value.Value); }
                }
            }
        }

        public void Serialize(ref ushort value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadUInt16Packed() : m_Reader.ReadUInt16();
            else { if (packed) { m_Writer.WriteUInt16Packed(value); } else { m_Writer.WriteUInt16(value); }}
        }

        public void Serialize(ref ushort? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadUInt16Packed() : m_Reader.ReadUInt16()) : (ushort?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteUInt16Packed(value.Value); } else { m_Writer.WriteUInt16(value.Value); }
                }
            }
        }

        public void Serialize(ref int value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
            else { if (packed) { m_Writer.WriteInt32Packed(value); } else { m_Writer.WriteInt32(value); }}
        }

        public void Serialize(ref int? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32()) : (int?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteInt32Packed(value.Value); } else { m_Writer.WriteInt32(value.Value); }
                }
            }
        }

        public void Serialize(ref uint value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadUInt32Packed() : m_Reader.ReadUInt32();
            else { if (packed) { m_Writer.WriteUInt32Packed(value); } else { m_Writer.WriteUInt32(value); }}
        }

        public void Serialize(ref uint? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadUInt32Packed() : m_Reader.ReadUInt32()) : (uint?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteUInt32Packed(value.Value); } else { m_Writer.WriteUInt32(value.Value); }
                }
            }
        }

        public void Serialize(ref long value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadInt64Packed() : m_Reader.ReadInt64();
            else { if (packed) { m_Writer.WriteInt64Packed(value); } else { m_Writer.WriteInt64(value); }}
        }

        public void Serialize(ref long? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadInt64Packed() : m_Reader.ReadInt64()) : (long?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteInt64Packed(value.Value); } else { m_Writer.WriteInt64(value.Value); }
                }
            }
        }

        public void Serialize(ref ulong value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadUInt64Packed() : m_Reader.ReadUInt64();
            else { if (packed) { m_Writer.WriteUInt64Packed(value); } else { m_Writer.WriteUInt64(value); }}
        }

        public void Serialize(ref ulong? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadUInt64Packed() : m_Reader.ReadUInt64()) : (ulong?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteUInt64Packed(value.Value); } else { m_Writer.WriteUInt64(value.Value); }
                }
            }
        }

        public void Serialize(ref float value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadSinglePacked() : m_Reader.ReadSingle();
            else { if (packed) { m_Writer.WriteSinglePacked(value); } else { m_Writer.WriteSingle(value); }}
        }

        public void Serialize(ref float? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadSinglePacked() : m_Reader.ReadSingle()) : (float?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteSinglePacked(value.Value); } else { m_Writer.WriteSingle(value.Value); }
                }
            }
        }

        public void Serialize(ref double value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadDoublePacked() : m_Reader.ReadDouble();
            else { if (packed) { m_Writer.WriteDoublePacked(value); } else { m_Writer.WriteDouble(value); }}
        }

        public void Serialize(ref double? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadDoublePacked() : m_Reader.ReadDouble()) : (double?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteDoublePacked(value.Value); } else { m_Writer.WriteDouble(value.Value); }
                }
            }
        }

        public void Serialize(ref string value, bool packed = true)
        {
            if (IsReading)
            {
                var isSet = m_Reader.ReadBool();
                value = isSet ? (packed ? m_Reader.ReadStringPacked() : m_Reader.ReadString().ToString()) : null;
            }
            else
            {
                var isSet = value != null;
                m_Writer.WriteBool(isSet);
                if (isSet)
                {
                    if (packed) { m_Writer.WriteStringPacked(value); } else { m_Writer.WriteString(value); }
                }
            }
        }

        public void Serialize(ref Color value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadColorPacked() : m_Reader.ReadColor();
            else { if (packed) { m_Writer.WriteColorPacked(value); } else { m_Writer.WriteColor(value); }}
        }

        public void Serialize(ref Color? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadColorPacked() : m_Reader.ReadColor()) : (Color?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteColorPacked(value.Value); } else { m_Writer.WriteColor(value.Value); }
                }
            }
        }

        public void Serialize(ref Color32 value)
        {
            if (IsReading) value = m_Reader.ReadColor32();
            else m_Writer.WriteColor32(value);
        }

        public void Serialize(ref Color32? value)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? m_Reader.ReadColor32() : (Color32?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    m_Writer.WriteColor32(value.Value);
                }
            }
        }

        public void Serialize(ref Vector2 value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadVector2Packed() : m_Reader.ReadVector2();
            else { if (packed) { m_Writer.WriteVector2Packed(value); } else { m_Writer.WriteVector2(value); }}
        }

        public void Serialize(ref Vector2? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadVector2Packed() : m_Reader.ReadVector2()) : (Vector2?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteVector2Packed(value.Value); } else { m_Writer.WriteVector2(value.Value); }
                }
            }
        }

        public void Serialize(ref Vector3 value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadVector3Packed() : m_Reader.ReadVector3();
            else { if (packed) { m_Writer.WriteVector3Packed(value); } else { m_Writer.WriteVector3(value); }}
        }

        public void Serialize(ref Vector3? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadVector3Packed() : m_Reader.ReadVector3()) : (Vector3?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteVector3Packed(value.Value); } else { m_Writer.WriteVector3(value.Value); }
                }
            }
        }

        public void Serialize(ref Vector4 value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadVector4Packed() : m_Reader.ReadVector4();
            else { if (packed) { m_Writer.WriteVector4Packed(value); } else { m_Writer.WriteVector4(value); }}
        }

        public void Serialize(ref Vector4? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadVector4Packed() : m_Reader.ReadVector4()) : (Vector4?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteVector4Packed(value.Value); } else { m_Writer.WriteVector4(value.Value); }
                }
            }
        }

        public void Serialize(ref Quaternion value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadRotationPacked() : m_Reader.ReadRotation();
            else { if (packed) { m_Writer.WriteRotationPacked(value); } else { m_Writer.WriteRotation(value); }}
        }

        public void Serialize(ref Quaternion? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadRotationPacked() : m_Reader.ReadRotation()) : (Quaternion?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteRotationPacked(value.Value); } else { m_Writer.WriteRotation(value.Value); }
                }
            }
        }

        public void Serialize(ref Ray value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadRayPacked() : m_Reader.ReadRay();
            else { if (packed) { m_Writer.WriteRayPacked(value); } else { m_Writer.WriteRay(value); }}
        }

        public void Serialize(ref Ray? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadRayPacked() : m_Reader.ReadRay()) : (Ray?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteRayPacked(value.Value); } else { m_Writer.WriteRay(value.Value); }
                }
            }
        }
        
        public void Serialize(ref Ray2D value, bool packed = true)
        {
            if (IsReading) value = packed ? m_Reader.ReadRay2DPacked() : m_Reader.ReadRay2D();
            else { if (packed) { m_Writer.WriteRay2DPacked(value); } else { m_Writer.WriteRay2D(value); }}
        }
        
        public void Serialize(ref Ray2D? value, bool packed = true)
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                value = hasValue ? (packed ? m_Reader.ReadRay2DPacked() : m_Reader.ReadRay2D()) : (Ray2D?)null;
            }
            else
            {
                m_Writer.WriteBit(value.HasValue);
                if (value.HasValue)
                {
                    if (packed) { m_Writer.WriteRay2DPacked(value.Value); } else { m_Writer.WriteRay2D(value.Value); }
                }
            }
        }

        public unsafe void Serialize<TEnum>(ref TEnum value, bool packed = true) where TEnum : unmanaged, Enum
        {
            if (sizeof(TEnum) == sizeof(int))
            {
                if (IsReading)
                {
                    int intValue = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                    value = *(TEnum*)&intValue;
                }
                else
                {
                    TEnum enumValue = value;
                    if (packed) { m_Writer.WriteInt32Packed(*(int*)&enumValue); } else { m_Writer.WriteInt32(*(int*)&enumValue); }
                }
            }
            else if (sizeof(TEnum) == sizeof(byte))
            {
                if (IsReading)
                {
                    byte intValue = m_Reader.ReadByteDirect();
                    value = *(TEnum*)&intValue;
                }
                else
                {
                    TEnum enumValue = value;
                    m_Writer.WriteByte(*(byte*)&enumValue);
                }
            }
            else if (sizeof(TEnum) == sizeof(short))
            {
                if (IsReading)
                {
                    short intValue = packed ? m_Reader.ReadInt16Packed() : m_Reader.ReadInt16();
                    value = *(TEnum*)&intValue;
                }
                else
                {
                    TEnum enumValue = value;
                    if (packed) { m_Writer.WriteInt16Packed(*(short*)&enumValue); } else { m_Writer.WriteInt16(*(short*)&enumValue); }
                }
            }
            else if (sizeof(TEnum) == sizeof(long))
            {
                if (IsReading)
                {
                    long intValue = packed ? m_Reader.ReadInt64Packed() : m_Reader.ReadInt64();;
                    value = *(TEnum*)&intValue;
                }
                else
                {
                    TEnum enumValue = value;
                    if (packed) { m_Writer.WriteInt64Packed(*(long*)&enumValue); } else { m_Writer.WriteInt64(*(long*)&enumValue); }
                }
            }
            else if (IsReading)
            {
                value = default;
            }
        }

        public unsafe void Serialize<TEnum>(ref TEnum? value, bool packed = true) where TEnum : unmanaged, Enum
        {
            if (IsReading)
            {
                bool hasValue = m_Reader.ReadBit();
                if (hasValue)
                {
                    TEnum trueValue = default;
                    Serialize(ref trueValue, packed);
                    value = trueValue;
                }
                else
                {
                    value = null;
                }
            }
            else
            {
                bool hasValue = value.HasValue;
                m_Writer.WriteBit(hasValue);
                if (hasValue)
                {
                    TEnum trueValue = value.Value;
                    Serialize(ref trueValue, packed);
                }
            }
        }

        public void Serialize(ref bool[] array, bool packed = true)
        {
            if (IsReading)
            {
                var length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new bool[length] : null;
                for (var i = 0; i < length; ++i)
                {
                    array[i] = m_Reader.ReadBool();
                }
            }
            else
            {
                var length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
                for (var i = 0; i < length; ++i)
                {
                    m_Writer.WriteBool(array[i]);
                }
            }
        }
        
        public void Serialize(ref char[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new char[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadCharPacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new char[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadChar();
                    }
                }
            }
            else
            {
                var length = array?.Length ?? -1;
                if (packed)
                {
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteCharPacked(array[i]);
                    }
                }
                else
                {
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteChar(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref sbyte[] array, bool packed = true)
        {
            if (IsReading)
            {
                var length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new sbyte[length] : null;
                for (var i = 0; i < length; ++i)
                {
                    array[i] = m_Reader.ReadSByte();
                }
            }
            else
            {
                var length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
                for (var i = 0; i < length; ++i)
                {
                    m_Writer.WriteSByte(array[i]);
                }
            }
        }

        public void Serialize(ref byte[] array, bool packed = true)
        {
            if (IsReading)
            {
                var length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new byte[length] : null;
                for (var i = 0; i < length; ++i)
                {
                    array[i] = m_Reader.ReadByteDirect();
                }
            }
            else
            {
                var length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
                for (var i = 0; i < length; ++i)
                {
                    m_Writer.WriteByte(array[i]);
                }
            }
        }

        public void Serialize(ref short[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new short[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt16Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new short[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt16();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt16Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt16(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref ushort[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new ushort[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt16Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new ushort[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt16();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt16Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt16(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref int[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new int[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt32Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new int[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt32();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt32Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt32(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref uint[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new uint[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt32Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new uint[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt32();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt32Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt32(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref long[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new long[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt64Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new long[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadInt64();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt64Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteInt64(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref ulong[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new ulong[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt64Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new ulong[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadUInt64();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt64Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteUInt64(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref float[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new float[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadSinglePacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new float[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadSingle();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteSinglePacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteSingle(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref double[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new double[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadDoublePacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new double[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadDouble();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteDoublePacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteDouble(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref string[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new string[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        var isSet = m_Reader.ReadBool();
                        array[i] = isSet ? m_Reader.ReadStringPacked() : null;
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new string[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        var isSet = m_Reader.ReadBool();
                        array[i] = isSet ? m_Reader.ReadString().ToString() : null;
                    } 
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        var isSet = array[i] != null;
                        m_Writer.WriteBool(isSet);
                        if (isSet)
                        {
                            m_Writer.WriteStringPacked(array[i]);
                        }
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        var isSet = array[i] != null;
                        m_Writer.WriteBool(isSet);
                        if (isSet)
                        {
                            m_Writer.WriteString(array[i]);
                        }
                    }
                }
            }
        }

        public void Serialize(ref Color[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Color[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadColorPacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Color[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadColor();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteColorPacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteColor(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Color32[] array, bool packed = true)
        {
            if (IsReading)
            {
                var length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new Color32[length] : null;
                for (var i = 0; i < length; ++i)
                {
                    array[i] = m_Reader.ReadColor32();
                }
            }
            else
            {
                var length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
                for (var i = 0; i < length; ++i)
                {
                    m_Writer.WriteColor32(array[i]);
                }
            }
        }

        public void Serialize(ref Vector2[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Vector2[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector2Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Vector2[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector2();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector2Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector2(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Vector3[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Vector3[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector3Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Vector3[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector3();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector3Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector3(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Vector4[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Vector4[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector4Packed();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Vector4[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadVector4();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector4Packed(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteVector4(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Quaternion[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Quaternion[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRotationPacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Quaternion[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRotation();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRotationPacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRotation(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Ray[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Ray[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRayPacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Ray[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRay();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRayPacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRay(array[i]);
                    }
                }
            }
        }

        public void Serialize(ref Ray2D[] array, bool packed = true)
        {
            if (IsReading)
            {
                if (packed)
                {
                    var length = m_Reader.ReadInt32Packed();
                    array = length > -1 ? new Ray2D[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRay2DPacked();
                    }
                }
                else
                {
                    var length = m_Reader.ReadInt32();
                    array = length > -1 ? new Ray2D[length] : null;
                    for (var i = 0; i < length; ++i)
                    {
                        array[i] = m_Reader.ReadRay2D();
                    }
                }
            }
            else
            {
                if (packed)
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32Packed(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRay2DPacked(array[i]);
                    }
                }
                else
                {
                    var length = array?.Length ?? -1;
                    m_Writer.WriteInt32(length);
                    for (var i = 0; i < length; ++i)
                    {
                        m_Writer.WriteRay2D(array[i]);
                    }
                }
            }
        }

        public unsafe void Serialize<TEnum>(ref TEnum[] array, bool packed = true) where TEnum : unmanaged, Enum
        {
            int length;
            if (IsReading)
            {
                length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new TEnum[length] : null;
            }
            else
            {
                length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
            }

            if (sizeof(TEnum) == sizeof(int))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            int intValue = m_Reader.ReadInt32Packed();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            int intValue = m_Reader.ReadInt32();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt32Packed(*(int*)&enumValue);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt32(*(int*)&enumValue);
                        }
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(byte))
            {
                if (IsReading)
                {
                    for (var i = 0; i < length; ++i)
                    {
                        byte intValue = m_Reader.ReadByteDirect();
                        array[i] = *(TEnum*)&intValue;
                    }
                }
                else
                {
                    for (var i = 0; i < length; ++i)
                    {
                        TEnum enumValue = array[i];
                        m_Writer.WriteByte(*(byte*)&enumValue);
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(short))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            short intValue = m_Reader.ReadInt16Packed();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            short intValue = m_Reader.ReadInt16();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt16Packed(*(short*)&enumValue);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt16(*(short*)&enumValue);
                        }
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(long))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            long intValue = m_Reader.ReadInt64Packed();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            long intValue = m_Reader.ReadInt64();
                            array[i] = *(TEnum*)&intValue;
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt64Packed(*(long*)&enumValue);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            TEnum enumValue = array[i];
                            m_Writer.WriteInt64(*(long*)&enumValue);
                        }
                    }
                }
            }
            else if (IsReading)
            {
                array = default;
            }
        }
        
        /**
        public unsafe void Serialize<TEnum>(ref TEnum?[] array, bool packed = true) where TEnum : unmanaged, Enum
        {
            int length;
            if (IsReading)
            {
                length = packed ? m_Reader.ReadInt32Packed() : m_Reader.ReadInt32();
                array = length > -1 ? new TEnum?[length] : null;
            }
            else
            {
                length = array?.Length ?? -1;
                if (packed) { m_Writer.WriteInt32Packed(length); } else { m_Writer.WriteInt32(length); }
            }

            if (sizeof(TEnum) == sizeof(int))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                int intValue = m_Reader.ReadInt32Packed();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                int intValue = m_Reader.ReadInt32();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt32Packed(*(int*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt32(*(int*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(byte))
            {
                if (IsReading)
                {
                    for (var i = 0; i < length; ++i)
                    {
                        bool has = m_Reader.ReadBit();
                        if (has)
                        {
                            byte intValue = m_Reader.ReadByteDirect();
                            array[i] = *(TEnum*)&intValue;
                        }
                        else
                        {
                            array[i] = null;
                        }

                    }
                }
                else
                {
                    for (var i = 0; i < length; ++i)
                    {
                        if (array[i].HasValue)
                        {
                            TEnum value = array[i].Value;
                            m_Writer.WriteBit(true);
                            m_Writer.WriteByte(*(byte*)&value);
                        }
                        else
                        {
                            m_Writer.WriteBit(false);
                        }
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(short))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                short intValue = m_Reader.ReadInt16Packed();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                short intValue = m_Reader.ReadInt16();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt16Packed(*(short*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt16(*(short*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                }
            }
            else if (sizeof(TEnum) == sizeof(long))
            {
                if (IsReading)
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                long intValue = m_Reader.ReadInt64Packed();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            bool has = m_Reader.ReadBit();
                            if (has)
                            {
                                long intValue = m_Reader.ReadInt64();
                                array[i] = *(TEnum*)&intValue;
                            }
                            else
                            {
                                array[i] = null;
                            }
                        }
                    }
                }
                else
                {
                    if (packed)
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt64Packed(*(long*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < length; ++i)
                        {
                            if (array[i].HasValue)
                            {
                                TEnum value = array[i].Value;
                                m_Writer.WriteBit(true);
                                m_Writer.WriteInt64(*(long*)&value);
                            }
                            else
                            {
                                m_Writer.WriteBit(false);
                            }
                        }
                    }
                }
            }
            else if (IsReading)
            {
                array = default;
            }
        }
        */
    }
}
