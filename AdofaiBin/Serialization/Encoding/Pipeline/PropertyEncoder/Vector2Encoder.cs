#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class Vector2Encoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(Vec2) };
    // public PropertyType Handles { get; } = PropertyType.Vector2;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is Vec2 vec)
        {
            // cursor.WriteFloat(vec.X);
            // cursor.WriteFloat(vec.Y);
            cursor.WriteVec2(vec);
        }
        else
        {
            cursor.WriteVec2(new Vec2(0, 0));
        }
    }
}