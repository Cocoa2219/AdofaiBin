using System;
using System.Collections.Generic;
using System.Linq;
using AdofaiBin.Serialization.Encoding.Misc;
using AdofaiBin.Serialization.Decoding;
using AdofaiBin.Serialization.Reflection;
using AdofaiBin.Serialization.Schema.Event;
using AdofaiBin.Serialization.Schema.Migration;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema
{
    public sealed class LevelSchema
    {
        public bool IsOldLevel { get; set; }
        public List<float> AngleData { get; set; } = new();
        public string PathData { get; set; }

        public int Version { get; set; }

        public Dictionary<EventType, EventSchema> Settings { get; set; } = new();
        public List<EventSchema> Events { get; set; } = new();
        public List<EventSchema> Decorations { get; set; } = new();

        public bool DisableV15Features { get; set; }
        public bool LegacyCamRelativeTo { get; set; }
        public bool LegacyFlash { get; set; }
        public bool LegacyTween { get; set; }
        public bool OldCameraFollowStyle { get; set; }

        internal void AddEvent(EventType type, EventBase ev, JObject json, Type evType = null)
        {
            evType ??= ev.GetType();

            var schema = new EventSchema(ev);

            if (ev.Data.IsDecoration)
            {
                Decorations.Add(schema);
            }
            else if (type.IsSetting())
            {
                Settings.Add(type, schema);
            }
            else
            {
                Events.Add(schema);
            }

            SetProperties(schema, json, evType);
        }

        private void SetProperties(EventSchema schema, JObject json, Type type)
        {
            MigrateOldProps(json, schema.Type);

            var props = ReflectionCache.GetProps(type);

            schema.Floor = json.GetOptional("floor", 0);
            schema.Active = json.GetOptional("active", true);
            schema.Locked = json.GetOptional("locked", false);
            schema.Visible = json.GetOptional("visible", true);

            foreach (var kvp in json)
            {
                var key = kvp.Key;
                var token = kvp.Value;

                if (string.Equals(key, "eventType", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "floor", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "active", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "locked", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(key, "visible", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var propName = PascalCase(key);
                if (!props.TryGetValue(propName, out var tuple))
                {
                    continue;
                }

                if (schema.Type.IsSetting())
                {
                    // Set raw properties for settings events here, cause settings' layout is one kind of object
                    // so we have to set raw properties when we know that the property is for this settings

                    schema.Event.RawProperties[key] = token.Value<object>();
                }

                var targetProp = tuple.info;
                var setter = tuple.setter;

                try
                {
                    if (token != null)
                    {
                        var value = ValueDecoders.ValueDecoderRegistry.Decode(token, targetProp.PropertyType);
                        setter.Set(schema.Event, value);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return;

            string PascalCase(string str) =>
#if NET8_0_OR_GREATER
                string.Join(string.Empty, str.Split('_').Select(s => char.ToUpperInvariant(s[0]) + s.AsSpan(1).ToString()));
#else
                string.Concat(str.Split('_').Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1)));
#endif
        }

        private static readonly IMigration[] _migrations =
        [
            new DecTextMigration(),
            new DepthMigration(),
            new HitboxMigration(),
            new TargetPlanetMigration(),
            new UnscaledSizeMigration()
        ];

        private void MigrateOldProps(JObject obj, EventType type)
        {
            foreach (var migration in _migrations)
            {
                if (migration.EventTypes.Contains(type))
                {
                    migration.Migrate(obj);
                }
            }
        }
    }
}
