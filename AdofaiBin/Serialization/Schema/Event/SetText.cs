namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetText, "SetText", false, false)]
public sealed class SetText : EventBase
{
    public string DecText { get; set; } = "sampleText";
    public string Tag { get; set; }
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}