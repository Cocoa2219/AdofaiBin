#nullable enable
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema.DataType
{
    public enum ParticleSystemGradientMode : byte
    {
        Color,
        TwoColors,
        Gradient,
        TwoGradients,
        RandomColor
    }

    public enum GradientMode : byte
    {
        Blend,
        Fixed,
        PerceptualBlend
    }

    public sealed class MinMaxGradient
    {
        public ParticleSystemGradientMode Mode { get; set; }
        public Color32? ColorMin { get; set; }
        public Color32? ColorMax { get; set; }
        // public List<(float t, Color32 c)>? GradientMin { get; set; }
        // public List<(float t, Color32 c)>? GradientMax { get; set; }
        public Gradient? GradientMin { get; set; }
        public Gradient? GradientMax { get; set; }

        public readonly struct Gradient(
            GradientMode mode,
            List<(float t, Color32 c)> colorKeys,
            List<(float t, float a)> alphaKeys)
        {
            public readonly GradientMode Mode = mode;
            public readonly List<(float t, Color32 c)> ColorKeys = colorKeys;
            public readonly List<(float t, float a)> AlphaKeys = alphaKeys;
        }
    }
}