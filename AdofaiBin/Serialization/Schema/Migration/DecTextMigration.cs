using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema.Migration;

public class DecTextMigration : IMigration
{
    /// <inheritdoc />
    public EventType[] EventTypes { get; } = { EventType.AddDecoration };

    /// <inheritdoc />
    public void Migrate(JObject obj)
    {
        if (obj.TryGetValue("decText", out var value))
        {
            obj["decorationImage"] = value;
            obj.Remove("decText");
        }
    }
}