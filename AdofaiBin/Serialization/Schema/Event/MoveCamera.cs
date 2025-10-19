using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class MoveCamera : EventBase
{
    public MoveCamera() : base("MoveCamera", false, false) { }

    public float Duration { get; set; } = 1;
    public RandomMode DurationRandomMode { get; set; } = RandomMode.None;
    public float DurationRandomValue { get; set; } = 1;
    public CamMovementType RelativeTo { get; set; } = CamMovementType.Player;
    public Vec2 Position { get; set; } = new Vec2(0, 0);
    public RandomMode PositionRandomMode { get; set; } = RandomMode.None;
    public Vec2 PositionRandomValue { get; set; } = new Vec2(0, 0);
    public float Rotation { get; set; } = 0;
    public RandomMode RotationRandomMode { get; set; } = RandomMode.None;
    public float RotationRandomValue { get; set; } = 0;
    public float Zoom { get; set; } = 100;
    public RandomMode ZoomRandomMode { get; set; } = RandomMode.None;
    public int ZoomRandomValue { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public bool DontDisable { get; set; } = false;
    public bool MinVfxOnly { get; set; } = false;
    public string EventTag { get; set; }
}