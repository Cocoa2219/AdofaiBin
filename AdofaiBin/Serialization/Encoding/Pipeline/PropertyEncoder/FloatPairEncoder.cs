#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class FloatPairEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(FloatPair) };
    // public PropertyType Handles { get; } = PropertyType.FloatPair;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        var pair = value is FloatPair floatPair ? floatPair : new FloatPair(0f, 0f);
        cursor.WriteFloat(pair.A);
        cursor.WriteFloat(pair.B);
    }
}