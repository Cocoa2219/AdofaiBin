namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetText : EventBase
{
    public SetText() : base("SetText", false, false) { }

    public string DecText { get; set; } = "sampleText";
    public string Tag { get; set; }
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}