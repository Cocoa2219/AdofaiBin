#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class ArrayEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(Array) };
    // public PropertyType Handles { get; } = PropertyType.Array;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is Array arr)
        {
            cursor.WriteVarInt(arr.Length);
            foreach (var item in arr)
            {
                switch (item)
                {
                    case int i:
                        cursor.WriteVarInt(i);
                        break;
                    case float f:
                        cursor.WriteFloat(f);
                        break;
                    case string s:
                        cursor.WriteUtf8String(s);
                        break;
                    case bool b:
                        cursor.WriteByte((byte)(b ? 1 : 0));
                        break;
                    default:
                        cursor.WriteVarInt(0);
                        break;
                }
            }
        }
        else
        {
            cursor.WriteVarInt(0);
        }
    }
}