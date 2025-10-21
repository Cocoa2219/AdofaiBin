using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetSpeed, "SetSpeed", false, false)]
public sealed class SetSpeed : EventBase
{
    public SpeedType SpeedType { get; set; } = SpeedType.Bpm;
    public float BeatsPerMinute { get; set; } = 100;
    public float BpmMultiplier { get; set; } = 1;
    public float AngleOffset { get; set; } = 0;
}