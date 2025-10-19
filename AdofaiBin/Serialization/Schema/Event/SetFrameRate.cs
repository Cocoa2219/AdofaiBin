namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetFrameRate : EventBase
{
    public SetFrameRate() : base("SetFrameRate", false, false) { }

    public bool Enabled { get; set; } = true;
    public float FrameRate { get; set; } = 5;
    public float AngleOffset { get; set; } = 0;
}