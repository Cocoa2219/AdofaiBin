using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public interface IBlockWriter
{
    byte BlockId { get; }
    uint GetSize(EncodingContext context);
    ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default);
}

public static class BlockSizeExtensions
{
    internal static int VarUIntSize(ulong v)
    {
        var n = 1;
        while (v >= 0x80) { v >>= 7; n++; }
        return n;
    }

    internal static int VarIntSize(long v)
    {
        var uv = (ulong)((v << 1) ^ (v >> 63));
        return VarUIntSize(uv);
    }
}