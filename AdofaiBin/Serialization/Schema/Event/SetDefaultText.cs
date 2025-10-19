using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetDefaultText : EventBase
{
    public SetDefaultText() : base("SetDefaultText", false, false) { }

    public float Duration { get; set; } = 1;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public Color32 DefaultTextColor { get; set; } = new Color32(255, 255, 255, 255);
    public Color32 DefaultTextShadowColor { get; set; } = new Color32(0, 0, 0, 80);
    public Vec2 LevelTitlePosition { get; set; } = new Vec2(0, 0);
    public string LevelTitleText { get; set; }
    public string CongratsText { get; set; } = "status.congratulations";
    public string PerfectText { get; set; } = "status.allPurePerfect";
    public string EventTag { get; set; }
}