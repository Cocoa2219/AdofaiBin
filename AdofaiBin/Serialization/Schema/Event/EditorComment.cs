namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.EditorComment, "EditorComment", false, false)]
public sealed class EditorComment : EventBase
{
    public object Comment { get; set; } = null;
}