using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public interface IBlockWriter
{
    byte BlockId { get; }
    uint GetSize(in EncodingContext context);
    ValueTask WriteBlockAsync(in EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default);
}

public static class BlockSizeExtensions
{
    internal static int VarUIntSize(ulong v)
    {
        var n = 1;
        while (v >= 0x80) { v >>= 7; n++; }
        return n;
    }
}