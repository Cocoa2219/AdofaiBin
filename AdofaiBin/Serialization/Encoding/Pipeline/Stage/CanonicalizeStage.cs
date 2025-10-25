using System.Threading;
using System.Threading.Tasks;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

public class CanonicalizeStage : IStage<EncodingContext>
{
    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        if (!context.Options.Deterministic)
        {
            return default;
        }

        // TODO: Implement canonicalization logic here
        return default;
    }
}