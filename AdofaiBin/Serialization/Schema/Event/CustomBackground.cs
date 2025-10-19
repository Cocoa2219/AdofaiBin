using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class CustomBackground : EventBase
{
    public CustomBackground() : base("CustomBackground", false, false) { }

    public Color32 Color { get; set; } = new Color32(0, 0, 0, 255);
    public string BgImage { get; set; } = "";
    public Color32 ImageColor { get; set; } = new Color32(255, 255, 255, 255);
    public Vec2 Parallax { get; set; } = new Vec2(100, 100);
    public BgDisplayMode BgDisplayMode { get; set; } = BgDisplayMode.FitToScreen;
    public bool ImageSmoothing { get; set; } = true;
    public bool LockRot { get; set; } = false;
    public bool LoopBG { get; set; } = false;
    public int ScalingRatio { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}