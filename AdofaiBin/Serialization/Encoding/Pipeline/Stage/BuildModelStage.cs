using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.Exception;
using AdofaiBin.Serialization.Misc;
using AdofaiBin.Serialization.Schema;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

/// <summary>
/// Stage that builds the <see cref="LevelSchema"/> model from the root JSON.
/// </summary>
public class BuildModelStage : IStage<EncodingContext>
{
    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        var rootJson = context.RootJson;
        var model = context.Model;

        if (!rootJson.TryGetValue("settings", out var settingsToken) || settingsToken is not JObject settings)
        {
            throw new EncodingInvalidJsonException("Missing 'settings' object in root JSON.");
        }

        model.Version = settings.GetRequired<int>("version");

        if (model.Version > 15)
        {
            throw new EncodingFutureVersionException(model.Version);
        }

        model.LegacyFlash = model.Version < 4 || settings.GetOptional("legacyFlash", false);
        model.IsOldLevel = model.Version < 5 || settings.GetOptional("legacySpriteTiles", false);
        model.LegacyCamRelativeTo = model.Version < 11 || settings.GetOptional("legacyCamRelativeTo", false);

        model.Settings[EventType.LevelSettings] = BuildEventSchema(settings, context, EventType.LevelSettings);
    }

    private EventSchema BuildEventSchema(JObject json, EncodingContext context, EventType eventType)
    {
        var schema = new EventSchema { Type = eventType };

        var isSettingEvent = eventType.IsSetting();

        if (isSettingEvent)
        {
            schema.Floor = 0;
            schema.Active = true;
            schema.Visible = true;
            schema.Locked = false;
        }
        else
        {
            schema.Floor = json.GetRequired<int>("floor");
            schema.Active = json.GetOptional("active", true);
            schema.Visible = json.GetOptional("visible", true);
            schema.Locked = json.GetOptional("locked", false);
        }
    }
}