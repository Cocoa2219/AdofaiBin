namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.HallOfMirrors, "HallOfMirrors", false, false)]
public sealed class HallOfMirrors : EventBase
{
    public bool Enabled { get; set; } = true;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}