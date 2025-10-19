namespace AdofaiBin.Serialization.Schema.Event;

public sealed class HallOfMirrors : EventBase
{
    public HallOfMirrors() : base("HallOfMirrors", false, false) { }

    public bool Enabled { get; set; } = true;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}