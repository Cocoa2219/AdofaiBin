namespace AdofaiBin.Serialization.Schema.Event;

public sealed class EditorComment : EventBase
{
    public EditorComment() : base("EditorComment", false, false) { }

    public object Comment { get; set; } = null;
}