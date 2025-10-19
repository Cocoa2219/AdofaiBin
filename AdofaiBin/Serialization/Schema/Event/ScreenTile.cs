using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ScreenTile : EventBase
{
    public ScreenTile() : base("ScreenTile", false, false) { }

    public float Duration { get; set; } = 0;
    public Vec2 Tile { get; set; } = new Vec2(1, 1);
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}