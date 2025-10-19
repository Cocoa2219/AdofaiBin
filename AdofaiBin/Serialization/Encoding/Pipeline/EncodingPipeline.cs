using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class EncodingPipeline(params IStage<EncodingContext>[] stages)
{
    private readonly IList<IStage<EncodingContext>> _stages = stages;

    public async Task RunAsync(EncodingContext ctx, CancellationToken ct)
    {
        foreach (var s in _stages)
        {
            ct.ThrowIfCancellationRequested();
            await s.RunAsync(ctx, ct).ConfigureAwait(false);
        }
    }
}