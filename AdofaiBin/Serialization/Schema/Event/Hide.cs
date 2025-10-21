namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Hide, "Hide", false, true)]
public sealed class Hide : EventBase
{
    public bool HideJudgment { get; set; } = false;
    public bool HideTileIcon { get; set; } = false;
}