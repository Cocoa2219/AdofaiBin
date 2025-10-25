using System;
using System.Collections.Generic;
using AdofaiBin.Serialization.Schema.Enum;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema.Migration;

public class HitboxMigration : IMigration
{
    /// <inheritdoc />
    public EventType[] EventTypes { get; } = { EventType.AddDecoration };

    /// <inheritdoc />
    public void Migrate(JObject obj)
    {
        if (obj.TryGetValue("failHitbox", out var value))
        {
            switch (value.Type)
            {
                case JTokenType.String:
                    // obj.TryAdd("hitbox", (value.Value<string>() == "Enabled" ? HitboxType.Kill : HitboxType.None).ToString());
                    obj["hitbox"] = value.Value<string>() switch
                    {
                        "Enabled" => HitboxType.Kill.ToString(),
                        "Disabled" => HitboxType.None.ToString(),
                        _ => HitboxType.None.ToString()
                    };
                    break;
                case JTokenType.Boolean:
                    obj["hitbox"] = value.Value<bool>() ? HitboxType.Kill.ToString() : HitboxType.None.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}