#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class RatingEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public PropertyType Handles { get; } = PropertyType.Rating;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        var rating = 0;
        if (value is int r)
        {
            rating = r;
        }

        cursor.WriteVarInt(rating);
    }
}