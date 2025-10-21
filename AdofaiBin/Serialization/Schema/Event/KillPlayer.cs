namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.KillPlayer, "KillPlayer", false, false)]
public sealed class KillPlayer : EventBase
{
    public bool PlayAnimation { get; set; } = true;
    public string FailMessage { get; set; }
    public string EventTag { get; set; }
}