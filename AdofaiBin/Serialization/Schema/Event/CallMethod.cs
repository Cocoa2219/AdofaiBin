namespace AdofaiBin.Serialization.Schema.Event;

public sealed class CallMethod : EventBase
{
    public CallMethod() : base("CallMethod", false, false) { }

    public string Method { get; set; }
    public float AngleOffset { get; set; } = 0;
}