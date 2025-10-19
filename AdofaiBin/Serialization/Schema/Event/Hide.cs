namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Hide : EventBase
{
    public Hide() : base("Hide", false, true) { }

    public bool HideJudgment { get; set; } = false;
    public bool HideTileIcon { get; set; } = false;
}