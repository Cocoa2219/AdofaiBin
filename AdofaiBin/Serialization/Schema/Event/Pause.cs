using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Pause : EventBase
{
    public Pause() : base("Pause", false, false) { }

    public float Duration { get; set; } = 1;
    public int CountdownTicks { get; set; } = 0;
    public AngleCorrectionDirection AngleCorrectionDir { get; set; } = AngleCorrectionDirection.Backward;
}