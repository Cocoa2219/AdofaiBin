using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.RepeatEvents, "RepeatEvents", false, false)]
public sealed class RepeatEvents : EventBase
{
    public RepeatType RepeatType { get; set; } = RepeatType.Beat;
    public int Repetitions { get; set; } = 1;
    public int FloorCount { get; set; } = 1;
    public float Interval { get; set; } = 1;
    public bool ExecuteOnCurrentFloor { get; set; } = false;
    public string Tag { get; set; }
}