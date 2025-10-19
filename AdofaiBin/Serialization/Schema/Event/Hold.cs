namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Hold : EventBase
{
    public Hold() : base("Hold", false, true) { }

    public int Duration { get; set; } = 0;
    public int DistanceMultiplier { get; set; } = 100;
    public bool LandingAnimation { get; set; } = false;
}