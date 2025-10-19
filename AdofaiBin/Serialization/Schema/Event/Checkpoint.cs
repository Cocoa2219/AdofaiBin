namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Checkpoint : EventBase
{
    public Checkpoint() : base("Checkpoint", false, false) { }

    public int TileOffset { get; set; } = 0;
}