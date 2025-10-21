using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.PlaySound, "PlaySound", false, false)]
public sealed class PlaySound : EventBase
{
    public HitSound Hitsound { get; set; } = HitSound.Kick;
    public int HitsoundVolume { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}