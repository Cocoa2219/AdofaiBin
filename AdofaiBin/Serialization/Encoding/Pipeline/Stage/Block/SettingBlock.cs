using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class SettingBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x04;

    /// <inheritdoc />
    public uint GetSize(in EncodingContext context)
    {
        return 0;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(in EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        var model = context.Model;
        cursor.WriteVarUInt((ulong)model.Version);

    }
}