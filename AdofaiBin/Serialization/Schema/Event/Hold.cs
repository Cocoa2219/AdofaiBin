namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Hold, "Hold", false, true)]
public sealed class Hold : EventBase
{
    public int Duration { get; set; } = 0;
    public int DistanceMultiplier { get; set; } = 100;
    public bool LandingAnimation { get; set; } = false;
}