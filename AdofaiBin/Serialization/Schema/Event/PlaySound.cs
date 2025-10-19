using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class PlaySound : EventBase
{
    public PlaySound() : base("PlaySound", false, false) { }

    public HitSound Hitsound { get; set; } = HitSound.Kick;
    public int HitsoundVolume { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}