namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.AutoPlayTiles, "AutoPlayTiles", false, false)]
public sealed class AutoPlayTiles : EventBase
{
    public bool Enabled { get; set; } = true;
    public bool ShowStatusText { get; set; } = true;
    public bool SafetyTiles { get; set; } = false;
}