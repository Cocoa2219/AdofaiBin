using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema.Migration;

public class DepthMigration : IMigration
{
    /// <inheritdoc />
    public EventType[] EventTypes { get; } = [EventType.AddDecoration, EventType.AddText];

    /// <inheritdoc />
    public void Migrate(JObject obj)
    {
        if (obj.TryGetValue("depth", out var value))
        {
            var num = value.Value<int>();
            obj["parallax"] = num switch
            {
                1 => 0,
                -1 => 0,
                _ => num
            };
        }
    }
}