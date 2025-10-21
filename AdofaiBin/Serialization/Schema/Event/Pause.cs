using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Pause, "Pause", false, false)]
public sealed class Pause : EventBase
{
    public float Duration { get; set; } = 1;
    public int CountdownTicks { get; set; } = 0;
    public AngleCorrectionDirection AngleCorrectionDir { get; set; } = AngleCorrectionDirection.Backward;
}