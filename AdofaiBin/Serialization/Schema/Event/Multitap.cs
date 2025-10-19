namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Multitap : EventBase
{
    public Multitap() : base("Multitap", false, false) { }

    public int Taps { get; set; } = 2;
}