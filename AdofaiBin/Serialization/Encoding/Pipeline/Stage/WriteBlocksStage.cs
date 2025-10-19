using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

public class WriteBlocksStage(params IBlockWriter[] blockWriters) : IStage<EncodingContext>
{
    private readonly IReadOnlyList<IBlockWriter> _blockWriters = blockWriters;

    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        var cursor = new WriteCursor(context.Sink);
        return new ValueTask(Task.WhenAll(_blockWriters.Select(bw => bw.WriteAsync(context, cursor, ct))));
    }
}