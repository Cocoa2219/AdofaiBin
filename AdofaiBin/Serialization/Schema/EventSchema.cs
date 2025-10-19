#nullable enable
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema
{
    public sealed class EventSchema
    {
        public int Floor { get; set; } = 0;
        public EventType Type { get; set; } = EventType.None;
        public bool Active { get; set; } = true;
        public bool Locked { get; set; } = false;
        public bool Visible { get; set; } = true;

        // public EventInfoSchema Info { get; set; } = new();

        public Dictionary<string, object?> Data { get; set; } = new();
        public Dictionary<string, bool> Disabled { get; set; } = new();
    }

    public class EventInfoSchema
    {
        public bool? AllowFirstFloor { get; set; }
        public EventCategory[] Categories { get; set; } = [];
        public EventExecutionTime ExecutionTime { get; set; }
        public Group[] Groups { get; set; } = [];
        public bool IsDecoration { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Pro { get; set; }
        // Runtime one; Do not serialize
        // public Dictionary<string, PropertyInfoSchema> Properties { get; set; } = new();
        public bool StretchViewport { get; set; }
        public bool TaroDLC { get; set; }
        public EventType Type { get; set; }
        public bool UseGroups { get; set; }

        public struct Group
        {
            public string Name { get; set; }
            public string Icon { get; set; }
            public bool IsDefault { get; set; }
        }
    }
}