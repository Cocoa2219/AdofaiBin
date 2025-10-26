using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class PathBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x03;

    /// <inheritdoc />
    public uint GetSize(EncodingContext context)
    {
        var model = context.Model;
        uint size = 1;

        if (model.IsOldLevel)
        {
            var pathDataBytes = System.Text.Encoding.UTF8.GetBytes(model.PathData);
            size += (uint)BlockSizeExtensions.VarUIntSize((ulong)pathDataBytes.Length) + (uint)pathDataBytes.Length;
        }
        else
        {
            var angleData = model.AngleData;
            size += (uint)BlockSizeExtensions.VarUIntSize((ulong)angleData.Count);
            size += (uint)(angleData.Count * 4);
        }

        return size;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        var model = context.Model;
        cursor.WriteBool(model.IsOldLevel);

        if (model.IsOldLevel)
        {
            cursor.WriteUtf8String(model.PathData);
        }
        else
        {
            var angleData = model.AngleData;
            cursor.WriteVarUInt((ulong)angleData.Count);
            foreach (var f in angleData)
            {
                cursor.WriteFloat(f);
            }
        }

        return default;
    }
}