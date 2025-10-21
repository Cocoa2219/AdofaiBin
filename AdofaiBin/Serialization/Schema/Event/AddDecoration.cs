using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.AddDecoration, "AddDecoration", true, false)]
public sealed class AddDecoration : EventBase
{
    public string DecorationImage { get; set; } = "";
    public string Tag { get; set; }
    public Vec2 Position { get; set; } = new(0, 0);
    public DecPlacementType RelativeTo { get; set; } = DecPlacementType.Global;
    public int Floor { get; set; } = 0;
    public bool StickToFloor { get; set; } = false;
    public Vec2 PivotOffset { get; set; } = new(0, 0);
    public float Rotation { get; set; } = 0;
    public bool LockRotation { get; set; } = false;
    public Vec2 Scale { get; set; } = new(100, 100);
    public float ScaleMultiplier { get; set; } = 1;
    public bool LockScale { get; set; } = false;
    public Vec2 Tile { get; set; } = new(1, 1);
    public Color32 Color { get; set; } = new(255, 255, 255, 255);
    public float Opacity { get; set; } = 100;
    public int Depth { get; set; } = -1;
    public bool SyncFloorDepth { get; set; } = false;
    public Vec2 Parallax { get; set; } = new(0, 0);
    public Vec2 ParallaxOffset { get; set; } = new(0, 0);
    public bool ImageSmoothing { get; set; } = true;
    public DecorationBlendMode BlendMode { get; set; } = DecorationBlendMode.None;
    public MaskingType MaskingType { get; set; } = MaskingType.None;
    public string MaskingTarget { get; set; }
    public bool UseMaskingDepth { get; set; } = false;
    public int MaskingFrontDepth { get; set; } = -1;
    public int MaskingBackDepth { get; set; } = -1;
    public HitboxType Hitbox { get; set; } = HitboxType.None;
    public HitboxTriggerType HitboxTriggerType { get; set; } = HitboxTriggerType.Once;
    public float HitboxRepeatInterval { get; set; } = 1000;
    public string HitboxEventTag { get; set; }
    public HitboxDetectTarget HitboxDetectTarget { get; set; } = HitboxDetectTarget.Planet;
    public HitboxTargetPlanet HitboxTargetPlanet { get; set; } = HitboxTargetPlanet.Any;
    public string HitboxDecoTag { get; set; }
    public Hitbox FailHitboxType { get; set; } = Enum.Hitbox.Box;
    public Vec2 FailHitboxScale { get; set; } = new(100, 100);
    public Vec2 FailHitboxOffset { get; set; } = new(0, 0);
    public float FailHitboxRotation { get; set; } = 0;
    public string Components { get; set; }
}