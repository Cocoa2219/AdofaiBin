using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class FreeRoamTwirl : EventBase
{
    public FreeRoamTwirl() : base("FreeRoamTwirl", false, true) { }

    public Vec2 Position { get; set; } = new Vec2(1, 0);
}