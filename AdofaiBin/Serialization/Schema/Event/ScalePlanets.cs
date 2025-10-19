using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ScalePlanets : EventBase
{
    public ScalePlanets() : base("ScalePlanets", false, false) { }

    public float Duration { get; set; } = 1;
    public TargetPlanet TargetPlanet { get; set; } = TargetPlanet.FirePlanet;
    public float Scale { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}