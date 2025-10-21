using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.ChangeTrack, "ChangeTrack", false, false)]
public sealed class ChangeTrack : EventBase
{
    public TrackColorType TrackColorType { get; set; } = TrackColorType.Single;
    public Color32 TrackColor { get; set; } = new Color32(222, 187, 123, 255);
    public Color32 SecondaryTrackColor { get; set; } = new Color32(255, 255, 255, 255);
    public float TrackColorAnimDuration { get; set; } = 2;
    public TrackColorPulse TrackColorPulse { get; set; } = TrackColorPulse.None;
    public int TrackPulseLength { get; set; } = 10;
    public TrackStyle TrackStyle { get; set; } = TrackStyle.Standard;
    public TrackAnimationType TrackAnimation { get; set; } = TrackAnimationType.None;
    public float BeatsAhead { get; set; } = 3;
    public TrackAnimationType2 TrackDisappearAnimation { get; set; } = TrackAnimationType2.None;
    public float BeatsBehind { get; set; } = 4;
}