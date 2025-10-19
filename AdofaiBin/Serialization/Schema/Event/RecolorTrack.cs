using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class RecolorTrack : EventBase
{
    public RecolorTrack() : base("RecolorTrack", false, false) { }

    public TileRef StartTile { get; set; } = new TileRef();
    public TileRef EndTile { get; set; } = new TileRef();
    public int GapLength { get; set; } = 0;
    public float Duration { get; set; } = 0;
    public TrackColorType TrackColorType { get; set; } = TrackColorType.Single;
    public Color32 TrackColor { get; set; } = new Color32(222, 187, 123, 255);
    public Color32 SecondaryTrackColor { get; set; } = new Color32(255, 255, 255, 255);
    public float TrackColorAnimDuration { get; set; } = 2;
    public TrackColorPulse TrackColorPulse { get; set; } = TrackColorPulse.None;
    public int TrackPulseLength { get; set; } = 10;
    public TrackStyle TrackStyle { get; set; } = TrackStyle.Standard;
    public float TrackGlowIntensity { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}