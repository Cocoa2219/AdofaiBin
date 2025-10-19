using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class AddObject : EventBase
{
    public AddObject() : base("AddObject", true, false)
    {
    }

    public ObjectDecorationType ObjectType { get; set; } = ObjectDecorationType.Floor;
    public string Tag { get; set; }
    public PlanetDecorationColorType PlanetColorType { get; set; } = PlanetDecorationColorType.DefaultRed;
    public Color32 PlanetColor { get; set; } = new(255, 0, 0, 255);
    public Color32 PlanetTailColor { get; set; } = new(255, 0, 0, 255);
    public FloorDecorationType TrackType { get; set; } = FloorDecorationType.Normal;
    public float TrackAngle { get; set; } = 180;
    public FloorDecorationColorType TrackColorType { get; set; } = FloorDecorationColorType.Single;
    public Color32 TrackColor { get; set; } = new(222, 187, 123, 255);
    public Color32 SecondaryTrackColor { get; set; } = new(255, 255, 255, 255);
    public float TrackColorAnimDuration { get; set; } = 2;
    public float TrackOpacity { get; set; } = 100;
    public TrackStyle TrackStyle { get; set; } = TrackStyle.Standard;
    public CustomFloorIcon TrackIcon { get; set; } = CustomFloorIcon.None;
    public float TrackIconAngle { get; set; } = 0;
    public bool TrackIconFlipped { get; set; } = false;
    public bool TrackRedSwirl { get; set; } = false;
    public bool TrackGraySetSpeedIcon { get; set; } = false;
    public float TrackSetSpeedIconBpm { get; set; } = 100;
    public bool TrackGlowEnabled { get; set; } = false;
    public Color32 TrackGlowColor { get; set; } = new(255, 255, 255, 255);
    public bool TrackIconOutlines { get; set; } = false;
    public Vec2 Position { get; set; } = new(0, 0);
    public DecPlacementType RelativeTo { get; set; } = DecPlacementType.Global;
    public int Floor { get; set; } = 0;
    public Vec2 PivotOffset { get; set; } = new(0, 0);
    public float Rotation { get; set; } = 0;
    public bool LockRotation { get; set; } = false;
    public Vec2 Scale { get; set; } = new(100, 100);
    public bool LockScale { get; set; } = false;
    public int Depth { get; set; } = -1;
    public bool SyncFloorDepth { get; set; } = false;
    public Vec2 Parallax { get; set; } = new(0, 0);
    public Vec2 ParallaxOffset { get; set; } = new(0, 0);
}