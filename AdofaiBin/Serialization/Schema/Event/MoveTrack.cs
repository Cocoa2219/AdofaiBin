using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class MoveTrack : EventBase
{
    public MoveTrack() : base("MoveTrack", false, false) { }

    public TileRef StartTile { get; set; } = new TileRef();
    public TileRef EndTile { get; set; } = new TileRef();
    public int GapLength { get; set; } = 0;
    public float Duration { get; set; } = 1;
    public Vec2 PositionOffset { get; set; } = new Vec2(0, 0);
    public float RotationOffset { get; set; } = 0;
    public Vec2 Scale { get; set; } = new Vec2(0, 0);
    public float Opacity { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public bool MaxVfxOnly { get; set; } = false;
    public string EventTag { get; set; }
}