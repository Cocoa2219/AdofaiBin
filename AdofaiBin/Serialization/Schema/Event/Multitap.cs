namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Multitap, "Multitap", false, false)]
public sealed class Multitap : EventBase
{
    public int Taps { get; set; } = 2;
}