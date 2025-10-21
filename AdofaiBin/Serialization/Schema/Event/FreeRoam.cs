using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.FreeRoam, "FreeRoam", false, true)]
public sealed class FreeRoam : EventBase
{
    public int Duration { get; set; } = 16;
    public Vec2 Size { get; set; } = new Vec2(4, 4);
    public Vec2 PositionOffset { get; set; } = new Vec2(0, 0);
    public int OutTime { get; set; } = 4;
    public Ease OutEase { get; set; } = Ease.InOutSine;
    public HitSound HitsoundOnBeats { get; set; } = HitSound.None;
    public HitSound HitsoundOffBeats { get; set; } = HitSound.None;
    public int CountdownTicks { get; set; } = 4;
    public AngleCorrectionDirection AngleCorrectionDir { get; set; } = AngleCorrectionDirection.Backward;
}