namespace AdofaiBin.Serialization.Schema.Event;

public sealed class AutoPlayTiles : EventBase
{
    public AutoPlayTiles() : base("AutoPlayTiles", false, false) { }

    public bool Enabled { get; set; } = true;
    public bool ShowStatusText { get; set; } = true;
    public bool SafetyTiles { get; set; } = false;
}