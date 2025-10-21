namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.AddComponent, "AddComponent", false, false)]
public sealed class AddComponent : EventBase
{
    public string Component { get; set; }
    public string Properties { get; set; }
    public float Duration { get; set; } = 1;
    public float AngleOffset { get; set; } = 0;
}