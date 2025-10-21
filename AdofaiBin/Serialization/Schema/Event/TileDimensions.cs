namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.TileDimensions, "TileDimensions", false, true)]
public sealed class TileDimensions : EventBase
{
    public float Width { get; set; } = 100;
    public float Length { get; set; } = 100;
}