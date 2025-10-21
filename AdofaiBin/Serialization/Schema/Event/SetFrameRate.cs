namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetFrameRate, "SetFrameRate", false, false)]
public sealed class SetFrameRate : EventBase
{
    public bool Enabled { get; set; } = true;
    public float FrameRate { get; set; } = 5;
    public float AngleOffset { get; set; } = 0;
}