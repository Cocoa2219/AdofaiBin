#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class EnumEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public PropertyType Handles { get; } = PropertyType.Enum;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is EnumValue enumValue)
        {
            var typeName = enumValue.TypeName ?? string.Empty;
            cursor.WriteUtf8String(typeName);

            if (enumValue.Value is int intValue)
            {
                cursor.WriteVarInt(intValue);
            }
            else
            {
                var strValue = enumValue.Value?.ToString() ?? string.Empty;
                cursor.WriteUtf8String(strValue);
            }
        }
        else
        {
            cursor.WriteUtf8String(string.Empty);
            cursor.WriteVarInt(0);
        }
    }
}