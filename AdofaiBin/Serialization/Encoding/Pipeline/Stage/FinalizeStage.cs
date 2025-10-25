using System.Threading;
using System.Threading.Tasks;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

public class FinalizeStage : IStage<EncodingContext>
{
    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        return default;
    }
}