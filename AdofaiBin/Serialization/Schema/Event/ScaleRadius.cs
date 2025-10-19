namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ScaleRadius : EventBase
{
    public ScaleRadius() : base("ScaleRadius", false, true) { }

    public float Scale { get; set; } = 100;
}