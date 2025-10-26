#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public sealed class FloatEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(float), typeof(double) };
    // public PropertyType Handles => PropertyType.Float;

    /// <inheritdoc />
    public void Write(ref WriteCursor c, object? value)
    {
        var f = value switch
        {
            float value1 => value1,
            double d => (float)d,
            _ => 0f
        };
        c.WriteFloat(f);
    }
}