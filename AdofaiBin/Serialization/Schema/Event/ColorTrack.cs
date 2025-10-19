using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ColorTrack : EventBase
{
    public ColorTrack() : base("ColorTrack", false, false) { }

    public TrackColorType TrackColorType { get; set; } = TrackColorType.Single;
    public Color32 TrackColor { get; set; } = new Color32(222, 187, 123, 255);
    public Color32 SecondaryTrackColor { get; set; } = new Color32(255, 255, 255, 255);
    public float TrackColorAnimDuration { get; set; } = 2;
    public TrackColorPulse TrackColorPulse { get; set; } = TrackColorPulse.None;
    public int TrackPulseLength { get; set; } = 10;
    public TrackStyle TrackStyle { get; set; } = TrackStyle.Standard;
    public string TrackTexture { get; set; } = "";
    public float TrackTextureScale { get; set; } = 1;
    public float TrackGlowIntensity { get; set; } = 100;
    public bool FloorIconOutlines { get; set; } = false;
    public bool JustThisTile { get; set; } = false;
}