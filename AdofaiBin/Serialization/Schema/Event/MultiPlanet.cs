using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.MultiPlanet, "MultiPlanet", false, true)]
public sealed class MultiPlanet : EventBase
{
    public PlanetCount Planets { get; set; } = PlanetCount.TwoPlanets;
}