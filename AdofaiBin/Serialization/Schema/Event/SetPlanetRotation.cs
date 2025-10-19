using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetPlanetRotation : EventBase
{
    public SetPlanetRotation() : base("SetPlanetRotation", false, false) { }

    public Ease Ease { get; set; } = Ease.Linear;
    public int EaseParts { get; set; } = 1;
    public EasePartBehavior EasePartBehavior { get; set; } = EasePartBehavior.Mirror;
}