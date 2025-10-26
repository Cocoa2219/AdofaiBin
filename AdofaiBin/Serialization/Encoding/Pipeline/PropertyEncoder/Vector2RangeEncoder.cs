#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class Vector2RangeEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(Vec2Range) };
    // public PropertyType Handles { get; } = PropertyType.Vector2Range;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        var vector2Range = (Vec2Range?)value ?? new Vec2Range(new Vec2(0, 0), new Vec2(0, 0));
        // cursor.WriteFloat(vector2Range.Min.X);
        // cursor.WriteFloat(vector2Range.Min.Y);
        // cursor.WriteFloat(vector2Range.Max.X);
        // cursor.WriteFloat(vector2Range.Max.Y);
        cursor.WriteVec2(vector2Range.Min);
        cursor.WriteVec2(vector2Range.Max);
    }
}