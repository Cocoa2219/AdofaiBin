using AdofaiBin.Serialization.Encoding.Misc;
using AdofaiBin.Serialization.Schema.Enum;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema.Migration;

public class UnscaledSizeMigration : IMigration
{
    /// <inheritdoc />
    public EventType[] EventTypes { get; } = [EventType.CustomBackground, EventType.BackgroundSettings];

    /// <inheritdoc />
    public void Migrate(JObject obj)
    {
        var flag = obj.GetOptional("bgDisplayMode", BgDisplayMode.FitToScreen) == BgDisplayMode.Unscaled;
        if (obj.TryGetValue("unscaledSize", out var value) || flag)
        {
            if (value != null) obj["scalingRatio"] = flag ? value.Value<int>() : 100;
            obj.Remove("unscaledSize");
        }
    }
}