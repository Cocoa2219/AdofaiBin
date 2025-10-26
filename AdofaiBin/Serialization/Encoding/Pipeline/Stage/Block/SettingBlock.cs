using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class SettingBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x04;

    /// <inheritdoc />
    public uint GetSize(EncodingContext context)
    {
        var size = (uint)context.Model.Settings.Sum(x => EventBlock.GetEventSize(context, x.Value));
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        var model = context.Model;
        cursor.WriteVarUInt((ulong)model.Version);
        foreach (var kind in context.Model.Settings.OrderBy(x => context.EventKinds.GetOrAdd(x.Key)))
        {
            EventBlock.WriteEvent(context, ref cursor, kind.Value);
        }

        cursor.WriteBool(model.LegacyFlash);
        cursor.WriteBool(model.LegacyCamRelativeTo);
        cursor.WriteBool(model.IsOldLevel);
        cursor.WriteBool(model.LegacyTween);
        cursor.WriteBool(model.DisableV15Features);

        return default;
    }
}