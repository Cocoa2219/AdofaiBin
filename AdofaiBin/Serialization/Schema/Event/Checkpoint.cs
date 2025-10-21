namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Checkpoint, "Checkpoint", false, false)]
public sealed class Checkpoint : EventBase
{
    public int TileOffset { get; set; } = 0;
}