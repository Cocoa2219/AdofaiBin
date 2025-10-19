#nullable enable
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;

public class IntEncoder : IPropertyEncoder
{
    public PropertyType Handles => PropertyType.Int;

    public void Write(ref WriteCursor c, object? value)
    {
        var v = 0; if (value is int i) v = i;
        c.WriteVarInt(v);
    }
}