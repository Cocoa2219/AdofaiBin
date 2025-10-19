#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class LongStringEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public PropertyType Handles { get; } = PropertyType.LongString;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        var str = value?.ToString() ?? string.Empty;
        cursor.WriteUtf8String(str);
    }
}