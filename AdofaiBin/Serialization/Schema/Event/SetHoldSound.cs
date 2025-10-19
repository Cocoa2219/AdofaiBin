using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetHoldSound : EventBase
{
    public SetHoldSound() : base("SetHoldSound", false, true) { }

    public HoldStartSound HoldStartSound { get; set; } = HoldStartSound.Fuse;
    public HoldLoopSound HoldLoopSound { get; set; } = HoldLoopSound.Fuse;
    public HoldEndSound HoldEndSound { get; set; } = HoldEndSound.Fuse;
    public HoldMidSound HoldMidSound { get; set; } = HoldMidSound.Fuse;
    public HoldMidSoundType HoldMidSoundType { get; set; } = HoldMidSoundType.Once;
    public float HoldMidSoundDelay { get; set; } = 0.5f;
    public HoldMidSoundTimingRelativeTo HoldMidSoundTimingRelativeTo { get; set; } = HoldMidSoundTimingRelativeTo.End;
    public int HoldSoundVolume { get; set; } = 100;
}