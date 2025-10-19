using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetSpeed : EventBase
{
    public SetSpeed() : base("SetSpeed", false, false) { }

    public SpeedType SpeedType { get; set; } = SpeedType.Bpm;
    public float BeatsPerMinute { get; set; } = 100;
    public float BpmMultiplier { get; set; } = 1;
    public float AngleOffset { get; set; } = 0;
}