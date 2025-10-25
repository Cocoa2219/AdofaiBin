using AdofaiBin.Serialization.Encoding.Misc;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema.Migration;

public class TargetPlanetMigration : IMigration
{
    /// <inheritdoc />
    public EventType[] EventTypes { get; } = [EventType.ScalePlanets];

    /// <inheritdoc />
    public void Migrate(JObject obj)
    {
        var text = obj.GetOptional<string>("targetPlanet", null);
        if (text is "Both")
        {
            obj["targetPlanet"] = "All";
        }
    }
}