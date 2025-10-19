#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class FileEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public PropertyType Handles { get; } = PropertyType.File;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        // just path as string
        var str = value?.ToString() ?? string.Empty;
        cursor.WriteUtf8String(str);
    }
}