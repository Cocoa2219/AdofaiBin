namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ScaleMargin : EventBase
{
    public ScaleMargin() : base("ScaleMargin", false, true) { }

    public float Scale { get; set; } = 100;
}