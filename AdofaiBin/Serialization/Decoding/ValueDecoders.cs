#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using AdofaiBin.Serialization.Schema.DataType;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Decoding;

public static class ValueDecoders
{
    public static class ValueDecoderRegistry
    {
        private static readonly List<IValueDecoder> _decoders = new()
        {
            new NullDecoder(),
            new StringDecoder(),
            new BoolDecoder(),
            new IntDecoder(),
            new FloatDecoder(),
            new EnumDecoder(),
            new Color32Decoder(),
            new Vec2Decoder(),
            new FloatPairDecoder(),
            new Vec2RangeDecoder(),
            new TileRefDecoder(),
            new ListDecoder(),
            new ArrayDecoder(),
            new MinMaxGradientDecoder(),
            new FallbackToObjectDecoder()
        };

        public static object? Decode(JToken token, Type targetType)
        {
            foreach (var d in _decoders)
                if (d.CanDecode(token.Type, targetType))
                    return d.Decode(token, targetType);
            // Should not reach due to fallback
            return token.ToObject(targetType);
        }
    }

    private static float ParseFloat(string s)
    {
        return float.Parse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
    }

    private static int ParseInt(string s)
    {
        return int.Parse(s, NumberStyles.Integer, CultureInfo.InvariantCulture);
    }

    private sealed class NullDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return type == JTokenType.Null;
        }

        public object? Decode(JToken token, Type targetType)
        {
            if (token.Type == JTokenType.Null)
            {
                if (!targetType.IsValueType || Nullable.GetUnderlyingType(targetType) != null)
                    return null;
                return Activator.CreateInstance(targetType);
            }

            throw new InvalidOperationException();
        }
    }

    private sealed class StringDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return targetType == typeof(string);
        }

        public object Decode(JToken token, Type targetType)
        {
            return token.Value<string>() ?? string.Empty;
        }
    }

    private sealed class BoolDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return targetType == typeof(bool) || targetType == typeof(bool?);
        }

        public object? Decode(JToken token, Type targetType)
        {
            return token.Value<bool>();
        }
    }

    private sealed class IntDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            var t = Nullable.GetUnderlyingType(targetType) ?? targetType;
            return t == typeof(int) || t == typeof(short) || t == typeof(byte) || t == typeof(long);
        }

        public object Decode(JToken token, Type targetType)
        {
            return token.Value<int>();
        }
    }

    private sealed class FloatDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            var t = Nullable.GetUnderlyingType(targetType) ?? targetType;
            return t == typeof(float) || t == typeof(double);
        }

        public object Decode(JToken token, Type targetType)
        {
            return token.Value<float>();
        }
    }

    private sealed class EnumDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            var t = Nullable.GetUnderlyingType(targetType) ?? targetType;
            return t.IsEnum;
        }

        public object? Decode(JToken token, Type targetType)
        {
            var t = Nullable.GetUnderlyingType(targetType) ?? targetType;
            if (token.Type == JTokenType.Integer) return Enum.ToObject(t, token.Value<int>());
            var s = token.Value<string>() ?? string.Empty;
            try
            {
                return Enum.Parse(t, s, true);
            }
            catch
            {
                var s2 = s.Replace(" ", string.Empty).Replace("_", string.Empty);
                foreach (var name in Enum.GetNames(t))
                    if (string.Equals(name, s2, StringComparison.OrdinalIgnoreCase))
                        return Enum.Parse(t, name);
                return Activator.CreateInstance(t);
            }
        }
    }

    private sealed class Color32Decoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(Color32);
        }

        public object Decode(JToken token, Type targetType)
        {
            if (token.Type == JTokenType.Integer)
            {
                var v = (uint)token.Value<long>();
                return Color32.FromUInt32ARGB(v);
            }

            var s = token.Value<string>() ?? string.Empty;
#if NET8_0_OR_GREATER
            var hex = s.StartsWith("#") ? s[1..] : s;
            switch (hex.Length)
            {
                case 6:
                {
                    var r = byte.Parse(hex[..2], NumberStyles.HexNumber);
                    var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    return Color32.FromRgb(r, g, b);
                }
                case 8:
                {
                    // RRGGBBAA
                    // var a = byte.Parse(hex[..2], NumberStyles.HexNumber);
                    // var r = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    // var g = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    // var b = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
                    var r = byte.Parse(hex[..2], NumberStyles.HexNumber);
                    var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    var a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
                    return new Color32(a, r, g, b);
                }
                default:
                    return Color32.FromRgb(0, 0, 0);
            }
#else
            var hex = s.Length > 0 && s[0] == '#' ? s.Substring(1) : s;
            switch (hex.Length)
            {
                case 6:
                {
                    var r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                    var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    return Color32.FromRgb(r, g, b);
                }
                case 8:
                {
                    // RRGGBBAA
                    // var a = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                    // var r = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    // var g = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    // var b = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
                    var r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                    var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                    var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
                    var a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
                    return new Color32(a, r, g, b);
                }
                default:
                    return Color32.FromRgb(0, 0, 0);
            }
#endif
        }
    }

    private sealed class Vec2Decoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(Vec2);
        }

        public object Decode(JToken token, Type targetType)
        {
            switch (token.Type)
            {
                case JTokenType.Array:
                {
                    var arr = (JArray)token;
                    var x = arr.Count > 0 ? arr[0].ToObject<float>() : 0f;
                    var y = arr.Count > 1 ? arr[1].ToObject<float>() : 0f;
                    return new Vec2(x, y);
                }
                case JTokenType.Object:
                {
                    var obj = (JObject)token;
                    var x = obj.TryGetValue("x", StringComparison.OrdinalIgnoreCase, out var xv)
                        ? xv.Value<float>()
                        : 0f;
                    var y = obj.TryGetValue("y", StringComparison.OrdinalIgnoreCase, out var yv)
                        ? yv.Value<float>()
                        : 0f;
                    return new Vec2(x, y);
                }
            }

            var s = token.ToString();
            var parts = s.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2) return new Vec2(ParseFloat(parts[0]), ParseFloat(parts[1]));
            return Vec2.Zero;
        }
    }

    private sealed class FloatPairDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(FloatPair);
        }

        public object Decode(JToken token, Type targetType)
        {
            switch (token.Type)
            {
                case JTokenType.Array:
                {
                    var arr = (JArray)token;
                    var a = arr.Count > 0 ? arr[0].ToObject<float>() : 0f;
                    var b = arr.Count > 1 ? arr[1].ToObject<float>() : 0f;
                    return new FloatPair(a, b);
                }
                case JTokenType.Object:
                {
                    var obj = (JObject)token;
                    var a = obj.TryGetValue("a", StringComparison.OrdinalIgnoreCase, out var av)
                        ? av.Value<float>()
                        : 0f;
                    var b = obj.TryGetValue("b", StringComparison.OrdinalIgnoreCase, out var bv)
                        ? bv.Value<float>()
                        : 0f;
                    return new FloatPair(a, b);
                }
            }

            var s = token.ToString();
            var parts = s.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2) return new FloatPair(ParseFloat(parts[0]), ParseFloat(parts[1]));
            return new FloatPair(0f, 0f);
        }
    }

    private sealed class Vec2RangeDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(Vec2Range);
        }

        public object Decode(JToken token, Type targetType)
        {
            if (token.Type == JTokenType.Array)
            {
                var arr = (JArray)token;
                var min = arr.Count > 0 ? parseVec(arr[0]) : Vec2.Zero;
                var max = arr.Count > 1 ? parseVec(arr[1]) : Vec2.Zero;
                return new Vec2Range(min, max);
            }

            if (token.Type == JTokenType.Object)
            {
                var obj = (JObject)token;
                var min = obj.TryGetValue("min", StringComparison.OrdinalIgnoreCase, out var minT)
                    ? parseVec(minT)
                    : Vec2.Zero;
                var max = obj.TryGetValue("max", StringComparison.OrdinalIgnoreCase, out var maxT)
                    ? parseVec(maxT)
                    : Vec2.Zero;
                return new Vec2Range(min, max);
            }

            var s = token.ToString();
            var parts = s.Split('|');
            if (parts.Length == 2)
            {
                var p1 = JToken.FromObject(parts[0]);
                var p2 = JToken.FromObject(parts[1]);
                return new Vec2Range(parseVec(p1), parseVec(p2));
            }

            return new Vec2Range(Vec2.Zero, Vec2.Zero);

            Vec2 parseVec(JToken t)
            {
                return (Vec2)new Vec2Decoder().Decode(t, typeof(Vec2));
            }
        }
    }

    private sealed class TileRefDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(TileRef);
        }

        public object Decode(JToken token, Type targetType)
        {
            switch (token.Type)
            {
                case JTokenType.Integer:
                    return new TileRef((int)token, TileRelativeTo.ThisTile);
                case JTokenType.Object:
                {
                    var obj = (JObject)token;
                    var index = obj.TryGetValue("index", StringComparison.OrdinalIgnoreCase, out var iv)
                        ? iv.Value<int>()
                        : 0;
                    var relStr = obj.TryGetValue("relativeTo", StringComparison.OrdinalIgnoreCase, out var rv)
                        ? rv.Value<string>()
                        : "ThisTile";
                    if (!Enum.TryParse(relStr, true, out TileRelativeTo rel)) rel = TileRelativeTo.ThisTile;
                    return new TileRef(index, rel);
                }
                case JTokenType.Array:
                {
                    var arr = (JArray)token;
                    var index = arr.Count > 0 ? arr[0].ToObject<int>() : 0;
                    var rel = TileRelativeTo.ThisTile;
                    if (arr.Count > 1)
                    {
                        var relStr = arr[1].ToObject<string>() ?? "ThisTile";
                        if (!Enum.TryParse(relStr, true, out rel)) rel = TileRelativeTo.ThisTile;
                    }

                    return new TileRef(index, rel);
                }
                default:
                    // Fallback: parse string as int
                    return int.TryParse(token.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture,
                        out var idx)
                        ? new TileRef(idx, TileRelativeTo.ThisTile)
                        : new TileRef();
            }
        }
    }

    private sealed class ListDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Decode(JToken token, Type targetType)
        {
            var elemType = targetType.GetGenericArguments()[0];
            var list = (IList)Activator.CreateInstance(targetType)!;
            if (token.Type == JTokenType.Array)
                foreach (var item in (JArray)token)
                    list.Add(ValueDecoderRegistry.Decode(item, elemType));
            else
                // Single item to list
                list.Add(ValueDecoderRegistry.Decode(token, elemType));
            return list;
        }
    }

    private sealed class ArrayDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return targetType.IsArray;
        }

        public object Decode(JToken token, Type targetType)
        {
            var elemType = targetType.GetElementType()!;
            if (token.Type == JTokenType.Array)
            {
                var arrT = (JArray)token;
                var arr = Array.CreateInstance(elemType, arrT.Count);
                for (var i = 0; i < arrT.Count; i++) arr.SetValue(ValueDecoderRegistry.Decode(arrT[i], elemType), i);
                return arr;
            }

            var single = Array.CreateInstance(elemType, 1);
            single.SetValue(ValueDecoderRegistry.Decode(token, elemType), 0);
            return single;
        }
    }

    private sealed class MinMaxGradientDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return (Nullable.GetUnderlyingType(targetType) ?? targetType) == typeof(MinMaxGradient);
        }

        public object Decode(JToken token, Type targetType)
        {
            var gradient = new MinMaxGradient();
            if (token.Type != JTokenType.Object)
                return gradient;

            var colorDecoder = new Color32Decoder();

            var obj = (JObject)token;
            gradient.ColorMin = colorDecoder.Decode(
                obj.TryGetValue("color1", StringComparison.OrdinalIgnoreCase, out var minT)
                    ? minT
                    : JValue.CreateNull(),
                typeof(Color32)) is Color32 minColor
                ? minColor
                : Color32.FromRgb(0, 0, 0);
            gradient.ColorMax = colorDecoder.Decode(
                obj.TryGetValue("color2", StringComparison.OrdinalIgnoreCase, out var maxT)
                    ? maxT
                    : JValue.CreateNull(),
                typeof(Color32)) is Color32 maxColor
                ? maxColor
                : Color32.FromRgb(0, 0, 0);

            gradient.Mode = obj.TryGetValue("mode", StringComparison.OrdinalIgnoreCase, out var modeT)
                ? Enum.TryParse(modeT.ToString(), true, out ParticleSystemGradientMode mode)
                    ? mode
                    : ParticleSystemGradientMode.Color
                : ParticleSystemGradientMode.Color;

            if (obj.TryGetValue("gradient1", StringComparison.OrdinalIgnoreCase, out var grad1T) &&
                grad1T.Type == JTokenType.Object)
            {
                var gradObj = (JObject)grad1T;
                var m = gradObj.TryGetValue("mode", StringComparison.OrdinalIgnoreCase, out var mT)
                    ? Enum.TryParse(mT.ToString(), true, out GradientMode gm)
                        ? gm
                        : GradientMode.Blend
                    : GradientMode.Blend;

                var colorKeys = new List<(float t, Color32 c)>();
                if (gradObj.TryGetValue("colorKeys", StringComparison.OrdinalIgnoreCase, out var ckT) &&
                    ckT.Type == JTokenType.Array)
                    foreach (var ck in (JArray)ckT)
                        if (ck.Type == JTokenType.Object)
                        {
                            var ckObj = (JObject)ck;
                            var t = ckObj.TryGetValue("time", StringComparison.OrdinalIgnoreCase, out var tT)
                                ? tT.Value<float>()
                                : 0f;
                            var c = colorDecoder.Decode(
                                ckObj.TryGetValue("color", StringComparison.OrdinalIgnoreCase, out var cT)
                                    ? cT
                                    : JValue.CreateNull(),
                                typeof(Color32)) is Color32 col
                                ? col
                                : Color32.FromRgb(0, 0, 0);
                            colorKeys.Add((t, c));
                        }

                var alphaKeys = new List<(float t, float a)>();
                if (gradObj.TryGetValue("alphaKeys", StringComparison.OrdinalIgnoreCase, out var akT) &&
                    akT.Type == JTokenType.Array)
                    foreach (var ak in (JArray)akT)
                        if (ak.Type == JTokenType.Object)
                        {
                            var akObj = (JObject)ak;
                            var t = akObj.TryGetValue("time", StringComparison.OrdinalIgnoreCase, out var tT)
                                ? tT.Value<float>()
                                : 0f;
                            var a = akObj.TryGetValue("alpha", StringComparison.OrdinalIgnoreCase, out var aT)
                                ? aT.Value<float>()
                                : 0f;
                            alphaKeys.Add((t, a));
                        }

                gradient.GradientMin = new MinMaxGradient.Gradient(m, colorKeys, alphaKeys);
            }

            if (obj.TryGetValue("gradient2", StringComparison.OrdinalIgnoreCase, out var grad2T) &&
                grad2T.Type == JTokenType.Object)
            {
                var gradObj = (JObject)grad2T;
                var m = gradObj.TryGetValue("mode", StringComparison.OrdinalIgnoreCase, out var mT)
                    ? Enum.TryParse(mT.ToString(), true, out GradientMode gm)
                        ? gm
                        : GradientMode.Blend
                    : GradientMode.Blend;

                var colorKeys = new List<(float t, Color32 c)>();
                if (gradObj.TryGetValue("colorKeys", StringComparison.OrdinalIgnoreCase, out var ckT) &&
                    ckT.Type == JTokenType.Array)
                    foreach (var ck in (JArray)ckT)
                        if (ck.Type == JTokenType.Object)
                        {
                            var ckObj = (JObject)ck;
                            var t = ckObj.TryGetValue("time", StringComparison.OrdinalIgnoreCase, out var tT)
                                ? tT.Value<float>()
                                : 0f;
                            var c = colorDecoder.Decode(
                                ckObj.TryGetValue("color", StringComparison.OrdinalIgnoreCase, out var cT)
                                    ? cT
                                    : JValue.CreateNull(),
                                typeof(Color32)) is Color32 col
                                ? col
                                : Color32.FromRgb(0, 0, 0);
                            colorKeys.Add((t, c));
                        }

                var alphaKeys = new List<(float t, float a)>();
                if (gradObj.TryGetValue("alphaKeys", StringComparison.OrdinalIgnoreCase, out var akT) &&
                    akT.Type == JTokenType.Array)
                    foreach (var ak in (JArray)akT)
                        if (ak.Type == JTokenType.Object)
                        {
                            var akObj = (JObject)ak;
                            var t = akObj.TryGetValue("time", StringComparison.OrdinalIgnoreCase, out var tT)
                                ? tT.Value<float>()
                                : 0f;
                            var a = akObj.TryGetValue("alpha", StringComparison.OrdinalIgnoreCase, out var aT)
                                ? aT.Value<float>()
                                : 0f;
                            alphaKeys.Add((t, a));
                        }

                gradient.GradientMax = new MinMaxGradient.Gradient(m, colorKeys, alphaKeys);
            }

            return gradient;
        }
    }

    private sealed class FallbackToObjectDecoder : IValueDecoder
    {
        public bool CanDecode(JTokenType type, Type targetType)
        {
            return true;
        }

        public object? Decode(JToken token, Type targetType)
        {
            // Last resort: use Json.NET to materialize
            if (targetType == typeof(object))
                return token.ToObject<object>();
            return token.ToObject(targetType);
        }
    }
}