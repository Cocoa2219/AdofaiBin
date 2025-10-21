using System;
using System.Collections.Generic;
using System.Linq;
using AdofaiBin.Serialization.Misc;
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

            foreach (var kv in json)
            {

            }

            return;

            string PascalCase(string str) =>
                string.Concat(str.Split('_').Select(s => char.ToUpperInvariant(s[0]) + s[1..]));
        }

        private static readonly IMigration[] _migrations =
        [
            new DecTextMigration()
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