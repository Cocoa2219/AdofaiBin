#nullable enable
using System;
using System.Collections.Generic;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class ListEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(IList<object?>) };
    // public PropertyType Handles { get; } = PropertyType.List;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is not IList<object?> list)
        {
            cursor.WriteVarInt(0);
            return;
        }

        cursor.WriteVarInt(list.Count);
        foreach (var item in list)
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
}