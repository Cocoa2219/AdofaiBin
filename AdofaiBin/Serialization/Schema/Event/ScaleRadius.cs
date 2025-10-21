namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.ScaleRadius, "ScaleRadius", false, true)]
public sealed class ScaleRadius : EventBase
{
    public float Scale { get; set; } = 100;
}