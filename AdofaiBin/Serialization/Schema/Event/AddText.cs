using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class AddText : EventBase
{
    public AddText() : base("AddText", true, false)
    {
    }

    public string DecText { get; set; } = "sampleText";
    public string Tag { get; set; }
    public FontName Font { get; set; } = FontName.Default;
    public Vec2 Position { get; set; } = new(0, 0);
    public DecPlacementType RelativeTo { get; set; } = DecPlacementType.Global;
    public int Floor { get; set; } = 0;
    public Vec2 PivotOffset { get; set; } = new(0, 0);
    public float Rotation { get; set; } = 0;
    public bool LockRotation { get; set; } = false;
    public Vec2 Scale { get; set; } = new(100, 100);
    public bool LockScale { get; set; } = false;
    public Color32 Color { get; set; } = new(255, 255, 255, 255);
    public float Opacity { get; set; } = 100;
    public int Depth { get; set; } = -1;
    public Vec2 Parallax { get; set; } = new(0, 0);
    public Vec2 ParallaxOffset { get; set; } = new(0, 0);
}