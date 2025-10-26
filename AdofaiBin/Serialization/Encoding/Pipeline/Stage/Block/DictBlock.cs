using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class DictBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x02;

    /// <inheritdoc />
    public uint GetSize(EncodingContext context)
    {
        uint size = 0;

        size += (uint)BlockSizeExtensions.VarUIntSize((ulong)context.EventKinds.Items.Count);
        foreach (var kv in context.EventKinds.Items)
        {
            size += (uint)BlockSizeExtensions.VarUIntSize((ulong)kv.Key.GetHashCode());
            size += (uint)BlockSizeExtensions.VarUIntSize(kv.Value);
        }

        size += (uint)BlockSizeExtensions.VarUIntSize((ulong)context.KeyDict.Items.Count);
        foreach (var kv in context.KeyDict.Items)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(kv.Key);
            size += (uint)BlockSizeExtensions.VarUIntSize((ulong)bytes.Length) + (uint)bytes.Length;
            size += (uint)BlockSizeExtensions.VarUIntSize((ulong)kv.Value);
        }

        return size;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        cursor.WriteVarUInt((ulong)context.EventKinds.Items.Count);
        foreach (var kv in context.EventKinds.Items)
        {
            cursor.WriteVarUInt((ulong)kv.Key.GetHashCode());
            cursor.WriteVarUInt(kv.Value);
        }

        cursor.WriteVarUInt((ulong)context.KeyDict.Items.Count);
        foreach (var kv in context.KeyDict.Items)
        {
            cursor.WriteUtf8String(kv.Key);
            cursor.WriteVarUInt(kv.Value);
        }

        return default;
    }
}