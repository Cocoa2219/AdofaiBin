using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class MoveDecorations : EventBase
{
    public MoveDecorations() : base("MoveDecorations", false, false) { }

    public float Duration { get; set; } = 1;
    public string Tag { get; set; } = "editor.placeholder.sampleTag";
    public bool Visible { get; set; } = true;
    public DecPlacementType RelativeTo { get; set; } = DecPlacementType.Global;
    public string DecorationImage { get; set; } = "";
    public Vec2 PositionOffset { get; set; } = new Vec2(0, 0);
    public Vec2 PivotOffset { get; set; } = new Vec2(0, 0);
    public float RotationOffset { get; set; } = 0;
    public Vec2 Scale { get; set; } = new Vec2(0, 0);
    public Color32 Color { get; set; } = new Color32(255, 255, 255, 255);
    public float Opacity { get; set; } = 100;
    public int Depth { get; set; } = -1;
    public Vec2 Parallax { get; set; } = new Vec2(0, 0);
    public Vec2 ParallaxOffset { get; set; } = new Vec2(0, 0);
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
    public MaskingType MaskingType { get; set; } = MaskingType.None;
    public string MaskingTarget { get; set; }
    public bool UseMaskingDepth { get; set; } = false;
    public int MaskingFrontDepth { get; set; } = -1;
    public int MaskingBackDepth { get; set; } = -1;
}