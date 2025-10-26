#nullable enable
using System;
using System.Collections.Generic;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class EnumEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(Enum) };
    // public PropertyType Handles { get; } = PropertyType.Enum;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is Enum enumValue)
        {
            cursor.WriteVarInt(Convert.ToInt32(enumValue));
        }
        else
        {
            cursor.WriteVarInt(0);
        }
    }
}