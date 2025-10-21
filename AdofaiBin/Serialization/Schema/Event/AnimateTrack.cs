using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.AnimateTrack, "AnimateTrack", false, false)]
public sealed class AnimateTrack : EventBase
{
    public TrackAnimationType TrackAnimation { get; set; } = TrackAnimationType.None;
    public float BeatsAhead { get; set; } = 3;
    public TrackAnimationType2 TrackDisappearAnimation { get; set; } = TrackAnimationType2.None;
    public float BeatsBehind { get; set; } = 4;
}