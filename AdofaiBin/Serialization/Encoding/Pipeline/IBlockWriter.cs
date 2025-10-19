using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public interface IBlockWriter
{
    string BlockId { get; }
    Task WriteAsync(EncodingContext context, WriteCursor cursor, CancellationToken? ct = null);
}