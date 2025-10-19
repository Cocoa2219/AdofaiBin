namespace AdofaiBin.Serialization.Schema.Event;

public abstract class EventBase
{
    public string Name { get; }
    public bool IsDecoration { get; }
    public bool TaroDLC { get; }

    protected EventBase(string name, bool isDecoration, bool taroDlc)
    {
        Name = name;
        IsDecoration = isDecoration;
        TaroDLC = taroDlc;
    }
}