#nullable enable
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema.DataType
{
    public enum GradientMode : byte
    {
        Color,
        TwoColors,
        Gradient,
        TwoGradients,
        RandomColor
    }

    public sealed class MinMaxGradient
    {
        public GradientMode Mode { get; set; }
        public Color32? ColorMin { get; set; }
        public Color32? ColorMax { get; set; }
        public List<(float t, Color32 c)>? GradientMin { get; set; }
        public List<(float t, Color32 c)>? GradientMax { get; set; }
    }
}