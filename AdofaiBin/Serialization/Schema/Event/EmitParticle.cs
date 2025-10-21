namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.EmitParticle, "EmitParticle", false, false)]
public sealed class EmitParticle : EventBase
{
    public string Tag { get; set; } = "editor.placeholder.sampleTag";
    public int Count { get; set; } = 10;
    public string EventTag { get; set; }
    public float AngleOffset { get; set; } = 0;
}