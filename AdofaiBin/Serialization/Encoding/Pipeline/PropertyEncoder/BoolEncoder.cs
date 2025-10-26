#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public sealed class BoolEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(bool) };
    // public PropertyType Handles => PropertyType.Bool;

    /// <inheritdoc />
    public void Write(ref WriteCursor c, object? value)
    {
        var b = value is true;
        c.WriteBool(b);
    }
}