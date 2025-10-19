using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema
{
    /// <summary>
    /// Represents the schema for a <see cref="ADOFAI.LevelData"/>.
    /// </summary>
    public sealed class LevelSchema
    {
        /// <summary>
        /// Determines whether the level follows the old level format.
        /// Based on: <see cref="ADOFAI.LevelData.isOldLevel"/>
        /// </summary>
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
    }
}