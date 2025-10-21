using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.PositionTrack, "PositionTrack", false, false)]
public sealed class PositionTrack : EventBase
{
    public Vec2 PositionOffset { get; set; } = new Vec2(0, 0);
    public TileRef RelativeTo { get; set; } = new TileRef();
    public float Rotation { get; set; } = 0;
    public float Scale { get; set; } = 100;
    public float Opacity { get; set; } = 100;
    public bool JustThisTile { get; set; } = false;
    public bool EditorOnly { get; set; } = false;
    public bool StickToFloors { get; set; } = true;
}