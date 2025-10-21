using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetPlanetRotation, "SetPlanetRotation", false, false)]
public sealed class SetPlanetRotation : EventBase
{
    public Ease Ease { get; set; } = Ease.Linear;
    public int EaseParts { get; set; } = 1;
    public EasePartBehavior EasePartBehavior { get; set; } = EasePartBehavior.Mirror;
}