namespace AdofaiBin.Serialization.Schema.Event;

public sealed class TileDimensions : EventBase
{
    public TileDimensions() : base("TileDimensions", false, true)
    {
    }

    public float Width { get; set; } = 100;
    public float Length { get; set; } = 100;
}