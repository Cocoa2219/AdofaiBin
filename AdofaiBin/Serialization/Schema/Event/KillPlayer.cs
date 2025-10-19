namespace AdofaiBin.Serialization.Schema.Event;

public sealed class KillPlayer : EventBase
{
    public KillPlayer() : base("KillPlayer", false, false) { }

    public bool PlayAnimation { get; set; } = true;
    public string FailMessage { get; set; }
    public string EventTag { get; set; }
}