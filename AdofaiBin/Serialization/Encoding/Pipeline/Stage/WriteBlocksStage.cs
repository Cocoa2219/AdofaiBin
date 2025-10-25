using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

public class WriteBlocksStage(params IBlockWriter[] blockWriters) : IStage<EncodingContext>
{
    private readonly IReadOnlyList<IBlockWriter> _blockWriters = blockWriters;

    /// <inheritdoc />
    public async ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        var framer = new BlockFramer();
        foreach (var bw in _blockWriters)
        {
            await framer.WriteFramedBlockAsync(context, context.Sink, bw, ct);
        }
    }
}

public sealed class BlockFramer
{
    private readonly Crc32 _crc = new();

    public async ValueTask WriteFramedBlockAsync(EncodingContext context, IBinarySink sink, IBlockWriter writer, CancellationToken ct = default)
    {
        var headerCursor = new WriteCursor(sink);
        headerCursor.WriteByte(writer.BlockId);
        headerCursor.WriteUInt32(writer.GetSize(context));

        _crc.Reset();
        using var crcSink = new Crc32BinarySink(sink, _crc);
        var payloadCursor = new WriteCursor(crcSink);

        await writer.WriteBlockAsync(context, ref payloadCursor, ct);

        var trailerCursor = new WriteCursor(sink);
        trailerCursor.WriteUInt32(_crc.Value);
    }
}
