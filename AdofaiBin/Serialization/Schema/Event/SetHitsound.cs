using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetHitsound : EventBase
{
    public SetHitsound() : base("SetHitsound", false, false) { }

    public GameSound GameSound { get; set; } = GameSound.Hitsound;
    public HitSound Hitsound { get; set; } = HitSound.Kick;
    public int HitsoundVolume { get; set; } = 100;
}