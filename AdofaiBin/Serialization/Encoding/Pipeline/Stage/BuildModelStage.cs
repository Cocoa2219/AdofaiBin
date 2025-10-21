#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Encoding.Exception;
using AdofaiBin.Serialization.Misc;
using AdofaiBin.Serialization.Schema;
using AdofaiBin.Serialization.Schema.Event;
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
        var settings = rootJson.GetRequired<JObject>("settings");

        model.Version = settings.GetRequired<int>("version");

        if (model.Version > 15)
        {
            throw new EncodingFutureVersionException(model.Version);
        }

        model.LegacyFlash = model.Version < 4 || settings.GetOptional("legacyFlash", false);
        model.IsOldLevel = model.Version < 5 || settings.GetOptional("legacySpriteTiles", false);
        model.LegacyCamRelativeTo = model.Version < 11 || settings.GetOptional("legacyCamRelativeTo", false);

        // FillSettings(context, settings, model);
        // FillEvents(context, rootJson.GetRequired<JArray>("actions"), model);
        // FillDecorations(context, rootJson.GetRequired<JArray>("decorations"), model);

        var eventArr = rootJson.GetRequired<JArray>("actions");
        var decorationArr = rootJson.GetRequired<JArray>("decorations");

        AssertTypeMapInitialized();

        if (_eventTypeMap == null)
            throw new EncodingException("Event type map is not initialized.");

        foreach (var setting in EventTypeExtensions.SettingTypes)
        {
            model.AddEvent(setting, CreateEventInstance(setting), settings, _eventTypeMap[setting]);
        }

        foreach (var evToken in eventArr)
        {
            var evObj = (JObject)evToken;
            var typeValue = evObj.GetRequired<string>("eventType");
            var eventType = Enum.TryParse<EventType>(typeValue, ignoreCase: true, out var et)
                ? et
                : throw new EncodingInvalidDataException($"Unknown event type: {typeValue}");

            if (eventType.IsSetting() || eventType.IsDecoration()) continue;

            var evInstance = CreateEventInstance(eventType);
            model.AddEvent(eventType, evInstance, evObj, _eventTypeMap[eventType]);
        }

        foreach (var decToken in decorationArr)
        {
            var decObj = (JObject)decToken;
            var typeValue = decObj.GetRequired<string>("eventType");
            var eventType = Enum.TryParse<EventType>(typeValue, ignoreCase: true, out var et)
            ? et
            : throw new EncodingInvalidDataException($"Unknown decoration event type: {typeValue}");

            if (!eventType.IsDecoration()) continue;

            var evInstance = CreateEventInstance(eventType);
            model.AddEvent(eventType, evInstance, decObj, _eventTypeMap[eventType]);
        }

        return new ValueTask(Task.CompletedTask);
    }

    private static Dictionary<EventType, Type>? _eventTypeMap;

    private static void AssertTypeMapInitialized()
    {
        if (_eventTypeMap != null)
            return;

        _eventTypeMap = new Dictionary<EventType, Type>();
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var t in types)
        {
            if (!(t is { IsClass: true, IsAbstract: false } && typeof(EventBase).IsAssignableFrom(t)))
                continue;

            if (!Attribute.IsDefined(t, typeof(EventAttribute), inherit: false))
                continue;

            var data = t.GetCustomAttributesData()
                .First(c => c.AttributeType == typeof(EventAttribute));

            if (data.NamedArguments != null)
            {
                var raw =
                    data.ConstructorArguments.Count > 0
                        ? data.ConstructorArguments[0].Value
                        : data.NamedArguments
                            .FirstOrDefault(na => na.MemberName == "EventType")
                            .TypedValue.Value;

                if (raw is null) continue;

                EventType key;
                if (raw is string s)
                {
                    if (!Enum.TryParse(s, ignoreCase: true, out key))
                        continue;
                }
                else if (raw.GetType().IsEnum)
                {
                    key = (EventType)raw;
                }
                else
                {
                    key = (EventType)Enum.ToObject(typeof(EventType), Convert.ToInt32(raw, CultureInfo.InvariantCulture));
                }

                _eventTypeMap[key] = t;
            }
        }

        // .Where(t => t.IsClass && !t.IsAbstract && typeof(EventBase).IsAssignableFrom(t))
        // .Select(t => new
        // {
        //     Type = t,
        //     Attr = t.GetCustomAttributesData()
        //         .FirstOrDefault(c => c.AttributeType == typeof(EventAttribute))
        // })
        // .Where(x => x.Attr != null)
        // .Select(x => new
        // {
        //     x.Type,
        //     EventType = (int)x.Attr!.ConstructorArguments[0].Value!
        // })
        // .GroupBy(x => x.EventType)
        // .ToDictionary(g => g.Key, g => g.First().Type);
    }
    private static EventBase? CreateEventInstance(EventType eventType)
    {
        AssertTypeMapInitialized();

        if (_eventTypeMap != null && _eventTypeMap.TryGetValue(eventType, out var type))
        {
            return (EventBase?)Activator.CreateInstance(type);
        }

        return null;
    }

    private void FillSettings(EncodingContext context, JObject settings, LevelSchema model)
    {

    }

    private void FillEvents(EncodingContext context, JArray eventsArray, LevelSchema model) { }
    private void FillDecorations(EncodingContext context, JArray decorationsArray, LevelSchema model) { }
}