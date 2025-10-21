namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.ScaleMargin, "ScaleMargin", false, true)]
public sealed class ScaleMargin : EventBase
{
    public float Scale { get; set; } = 100;
}