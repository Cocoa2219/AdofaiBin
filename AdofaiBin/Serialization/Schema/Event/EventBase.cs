namespace AdofaiBin.Serialization.Schema.Event;

public abstract class EventBase
{
    public EventAttribute Data { get; internal set; }// public EventType Type { get; }
    // public string Name { get; }
    // public bool IsDecoration { get; }
    // public bool TaroDLC { get; }
    //
    // protected EventBase(string name, bool isDecoration, bool taroDlc, EventType? type = null)
    // {
    //     Name = name;
    //     IsDecoration = isDecoration;
    //     TaroDLC = taroDlc;
    //     Type = type ?? EventType.None;
    // }
}