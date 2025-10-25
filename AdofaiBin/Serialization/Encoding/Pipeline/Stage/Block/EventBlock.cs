using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class EventBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x03;

    /// <inheritdoc />
    public uint GetSize(in EncodingContext context)
    {
        return 0;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(in EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        return default;
    }

    public static void WriteEvent(in EncodingContext context, ref WriteCursor cursor, EventSchema ev)
    {
        cursor.WriteVarUInt(context.EventKinds.GetOrAdd(ev.Type));
    }
}