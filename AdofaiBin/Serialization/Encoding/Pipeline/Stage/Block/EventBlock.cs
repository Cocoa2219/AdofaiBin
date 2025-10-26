using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Reflection;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage.Block;

public class EventBlock : IBlockWriter
{
    /// <inheritdoc />
    public byte BlockId { get; } = 0x03;

    /// <inheritdoc />
    public uint GetSize(EncodingContext context)
    {
        return 0;
    }

    /// <inheritdoc />
    public ValueTask WriteBlockAsync(EncodingContext context, ref WriteCursor cursor, CancellationToken ct = default)
    {
        return default;
    }

    public static void WriteEvent(EncodingContext context, ref WriteCursor cursor, EventSchema ev)
    {
        cursor.WriteVarUInt(context.EventKinds.GetOrAdd(ev.Type));

        if (!ev.Type.IsSetting())
        {
            cursor.WriteVarInt(ev.Floor);
            cursor.WriteBool(ev.Active);
            cursor.WriteBool(ev.Visible);
            cursor.WriteBool(ev.Locked);
        }

        var props = ReflectionCache.GetProps(EventRegistry.GetEventType(ev.Type)).OrderBy(x => context.KeyDict.GetOrAdd(x.Value.info.Name));

        foreach (var prop in props)
        {
            context.Encoders.Write(prop.Value.info.PropertyType, ref cursor, prop.Value.getter.Get(ev));
        }
    }

    public static uint GetEventSize(EncodingContext context, EventSchema xValue)
    {
        long size = 0;
        size += (uint)BlockSizeExtensions.VarUIntSize(context.EventKinds.GetOrAdd(xValue.Type));

        if (!xValue.Type.IsSetting())
        {
            size += (uint)BlockSizeExtensions.VarIntSize(xValue.Floor);
            size += 1; // Active
            size += 1; // Visible
            size += 1; // Locked
        }

        var props = ReflectionCache.GetProps(EventRegistry.GetEventType(xValue.Type)).OrderBy(x => context.KeyDict.GetOrAdd(x.Value.info.Name));

        foreach (var prop in props)
        {
            size += context.Encoders.GetSize(prop.Value.info.PropertyType, prop.Value.getter.Get(xValue));
        }

        return size;
    }
}