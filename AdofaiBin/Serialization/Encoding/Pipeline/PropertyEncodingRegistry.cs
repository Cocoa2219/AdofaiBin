#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Encoding.Pipeline.PropertyEncoder;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class PropertyEncoderRegistry
{
    private readonly Dictionary<Type[], IPropertyEncoder> _map;

    public PropertyEncoderRegistry(IEnumerable<IPropertyEncoder> encoders)
    {
        _map = encoders.ToDictionary(e => e.Handles, e => e);
    }

    public static IPropertyEncoder[] AllEncoders { get; } =
    {
        new ArrayEncoder(),
        new BoolEncoder(),
        new ColorEncoder(),
        new EnumEncoder(),
        // new FileEncoder(),
        // new FilterPropertiesEncoder(),
        new FloatEncoder(),
        new FloatPairEncoder(),
        new IntEncoder(),
        new ListEncoder(),
        // new LongStringEncoder(),
        new MinMaxGradientEncoder(),
        // new RatingEncoder(),
        new StringEncoder(),
        new TileEncoder(),
        new Vector2Encoder(),
        new Vector2RangeEncoder()
    };

    public void Write(Type t, ref WriteCursor c, object? value)
    {
        // if (_map.TryGetValue(t, out var enc)) { enc.Write(ref c, value); return; }
        if (_map.FirstOrDefault(kv => kv.Key.Any(kt => kt == t)).Value is { } enc)
        {
            enc.Write(ref c, value);
            return;
        }

        c.WriteUtf8String(value == null ? "" : value.ToString());
    }
}