using System.Threading;
using System.Threading.Tasks;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public interface IStage<in TCtx>
{
    ValueTask RunAsync(TCtx context, CancellationToken ct);
}