using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetObject : EventBase
{
    public SetObject() : base("SetObject", false, false) { }

    public float Duration { get; set; } = 1;
    public string Tag { get; set; } = "editor.placeholder.sampleTag";
    public Color32 PlanetColor { get; set; } = new Color32(255, 0, 0, 255);
    public Color32 PlanetTailColor { get; set; } = new Color32(255, 0, 0, 255);
    public float TrackAngle { get; set; } = 180;
    public FloorDecorationColorType TrackColorType { get; set; } = FloorDecorationColorType.Single;
    public Color32 TrackColor { get; set; } = new Color32(222, 187, 123, 255);
    public Color32 SecondaryTrackColor { get; set; } = new Color32(255, 255, 255, 255);
    public float TrackColorAnimDuration { get; set; } = 2;
    public float TrackOpacity { get; set; } = 100;
    public TrackStyle TrackStyle { get; set; } = TrackStyle.Standard;
    public CustomFloorIcon TrackIcon { get; set; } = CustomFloorIcon.None;
    public float TrackIconAngle { get; set; } = 0;
    public bool TrackIconFlipped { get; set; } = false;
    public bool TrackRedSwirl { get; set; } = false;
    public bool TrackGraySetSpeedIcon { get; set; } = false;
    public bool TrackGlowEnabled { get; set; } = false;
    public Color32 TrackGlowColor { get; set; } = new Color32(255, 255, 255, 255);
    public bool TrackIconOutlines { get; set; } = false;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}