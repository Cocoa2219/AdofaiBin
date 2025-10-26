using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class HeaderBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x01;

    /// <inheritdoc />
    public uint GetSize(EncodingContext context)
    {
        return 12;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        // Magic 'ADOBIN' (6 bytes), version major/minor (2 bytes), header flags (4 bytes)
        cursor.WriteByte((byte)'A');
        cursor.WriteByte((byte)'D');
        cursor.WriteByte((byte)'O');
        cursor.WriteByte((byte)'B');
        cursor.WriteByte((byte)'I');
        cursor.WriteByte((byte)'N');
        cursor.WriteByte((byte)Constants.CurrentVersion.Major);
        cursor.WriteByte((byte)Constants.CurrentVersion.Minor);
        cursor.WriteUInt32(context.Options.HeaderFlags);
        return default;
    }
}