using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetHitsound, "SetHitsound", false, false)]
public sealed class SetHitsound : EventBase
{
    public GameSound GameSound { get; set; } = GameSound.Hitsound;
    public HitSound Hitsound { get; set; } = HitSound.Kick;
    public int HitsoundVolume { get; set; } = 100;
}