#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.Exception;
using AdofaiBin.Serialization.Encoding.Misc;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.Event;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

/// <summary>
///     Stage that builds the <see cref="LevelSchema" /> model from the root JSON.
/// </summary>
public class BuildModelStage : IStage<EncodingContext>
{
    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        var rootJson = context.RootJson;
        var model = context.Model;
        var settings = rootJson.GetRequired<JObject>("settings");

        model.Version = settings.GetRequired<int>("version");

        if (model.Version > 15) throw new EncodingFutureVersionException(model.Version);

        model.LegacyFlash = model.Version < 4 || settings.GetOptional("legacyFlash", false);
        model.IsOldLevel = model.Version < 5 || settings.GetOptional("legacySpriteTiles", false);
        model.LegacyCamRelativeTo = model.Version < 11 || settings.GetOptional("legacyCamRelativeTo", false);

        var eventArr = rootJson.GetRequired<JArray>("actions");
        var decorationArr = rootJson.GetRequired<JArray>("decorations");

        foreach (var setting in EventTypeExtensions.SettingTypes)
            model.AddEvent(setting, CreateEventInstance(setting), settings, EventRegistry.EventTypeMap[setting]);

        if (rootJson.TryGetValue("pathData", out var pathDataToken))
        {
            var str = pathDataToken.Value<string>();

            if (string.IsNullOrEmpty(str))
            {
                model.PathData = string.Empty;
                model.AngleData.Clear();
            }
            else
            {
                if (model.IsOldLevel)
                {
                    model.PathData = pathDataToken.Value<string>();
                    model.AngleData.Clear();
                }
                else
                {
                    model.PathData = string.Empty;
                    var angles = StringToAngleArray(str!);
                    model.AngleData.Clear();
                    model.AngleData.AddRange(angles);
                }
            }
        }
        else
        {
            model.AngleData.Clear();
            model.AngleData.AddRange(rootJson.GetRequired<JArray>("angleData").Values<float>());
            model.PathData = string.Empty;
        }

        foreach (var evToken in eventArr)
        {
            var evObj = (JObject)evToken;
            var typeValue = evObj.GetRequired<string>("eventType");
            var eventType = Enum.TryParse<EventType>(typeValue, true, out var et)
                ? et
                : throw new EncodingInvalidDataException($"Unknown event type: {typeValue}");

            if (eventType.IsSetting() || eventType.IsDecoration()) continue;

            var evInstance = CreateEventInstance(eventType, evObj);
            model.AddEvent(eventType, evInstance, evObj, EventRegistry.EventTypeMap[eventType]);
        }

        foreach (var decToken in decorationArr)
        {
            var decObj = (JObject)decToken;
            var typeValue = decObj.GetRequired<string>("eventType");
            var eventType = Enum.TryParse<EventType>(typeValue, true, out var et)
                ? et
                : throw new EncodingInvalidDataException($"Unknown decoration event type: {typeValue}");

            if (!eventType.IsDecoration()) continue;

            var evInstance = CreateEventInstance(eventType, decObj);
            model.AddEvent(eventType, evInstance, decObj, EventRegistry.EventTypeMap[eventType]);
        }

        return default;
    }

    private float[] StringToAngleArray(string s)
    {
        var res = new float[s?.Length ?? 0];
        var prev = 0f;

        for (var i = 0; i < res.Length; i++)
        {
            if (s != null)
            {
                var c = s[i];
                var a = GetAngleFromFloorCharDirectionWithCheck(c);
                var isAbsolute = a.HasValue;

                res[i] = prev = isAbsolute
                    ? a!.Value
                    : prev + c switch
                    {
                        '5' => 72f,
                        '6' => -72f,
                        '7' => 52f,
                        '8' => -52f,
                        '9' => -30f,
                        'h' => 120f,
                        'j' => -120f,
                        't' => 60f,
                        'y' => 300f,
                        _ => 0f
                    };
            }
        }

        return res;
    }

    private float? GetAngleFromFloorCharDirectionWithCheck(char direction)
    {
        float? angle = direction switch
        {
            '!' => 999f,

            'A' => 345f,
            'B' => 300f,
            'C' => 315f,
            'D' => 270f,
            'E' => 45f,
            'F' => 240f,
            'G' => 120f,
            'H' => 150f,
            'J' => 30f,
            'L' => 180f,
            'M' => 330f,
            'N' => 210f,
            'Q' => 135f,
            'R' => 0f,
            'T' => 60f,
            'U' => 90f,
            'V' => 255f,
            'W' => 165f,
            'Y' => 285f,
            'Z' => 225f,

            // lowercase
            'o' => 75f,
            'p' => 15f,
            'q' => 105f,
            'x' => 195f,

            _ => null
        };

        return angle;
    }

    private static EventBase? CreateEventInstance(EventType eventType, JObject? rawJson = null)
    {
        var evMap = EventRegistry.EventTypeMap;
        var evAMap = EventRegistry.EventAttributes;

        if (evMap != null && evMap.TryGetValue(eventType, out var type) &&
            evAMap.TryGetValue(eventType, out var _ev))
        {
            var instance = (EventBase?)Activator.CreateInstance(type);
            if (instance != null)
            {
                instance.Data = _ev;

                if (rawJson != null)
                {
                    foreach (var kvp in rawJson)
                    {
                        if (kvp.Value != null) instance.RawProperties[kvp.Key] = kvp.Value.Value<object>();
                    }
                }

                return instance;
            }
        }

        return null;
    }
}