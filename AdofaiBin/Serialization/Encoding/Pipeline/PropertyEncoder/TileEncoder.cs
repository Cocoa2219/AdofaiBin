#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class TileEncoder : IPropertyEncoder
{
    /// <inheritdoc />
    public Type[] Handles { get; } = new[] { typeof(TileRef) };
    // public PropertyType Handles { get; } = PropertyType.Tile;

    /// <inheritdoc />
    public void Write(ref WriteCursor cursor, object? value)
    {
        if (value is TileRef tileRef)
        {
            cursor.WriteVarInt(tileRef.Index);
            cursor.WriteByte((byte)tileRef.RelativeTo);
        }
        else
        {
            cursor.WriteVarInt(0);
            cursor.WriteByte((byte)TileRelativeTo.ThisTile);
        }
    }
}