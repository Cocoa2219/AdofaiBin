#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class ColorEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(Color32) };
    // public PropertyType Handles { get; } = PropertyType.Color;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        Color32 color;
        if (value is Color32 c)
        {
            color = c;
        }
        else
        {
            color = new Color32(255, 0, 0, 0);
        }

        // cursor.WriteByte(color.A);
        // cursor.WriteByte(color.R);
        // cursor.WriteByte(color.G);
        // cursor.WriteByte(color.B);
        cursor.WriteColor(color);
    }
}