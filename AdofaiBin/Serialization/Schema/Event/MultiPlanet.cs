using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class MultiPlanet : EventBase
{
    public MultiPlanet() : base("MultiPlanet", false, true) { }

    public PlanetCount Planets { get; set; } = PlanetCount.TwoPlanets;
}