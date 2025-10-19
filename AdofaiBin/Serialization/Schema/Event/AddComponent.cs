namespace AdofaiBin.Serialization.Schema.Event;

public sealed class AddComponent : EventBase
{
    public AddComponent() : base("AddComponent", false, false) { }

    public string Component { get; set; }
    public string Properties { get; set; }
    public float Duration { get; set; } = 1;
    public float AngleOffset { get; set; } = 0;
}