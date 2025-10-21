namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.CallMethod, "CallMethod", false, false)]
public sealed class CallMethod : EventBase
{
    public string Method { get; set; }
    public float AngleOffset { get; set; } = 0;
}