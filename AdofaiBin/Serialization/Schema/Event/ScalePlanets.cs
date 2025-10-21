using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.ScalePlanets, "ScalePlanets", false, false)]
public sealed class ScalePlanets : EventBase
{
    public float Duration { get; set; } = 1;
    public TargetPlanet TargetPlanet { get; set; } = TargetPlanet.FirePlanet;
    public float Scale { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}