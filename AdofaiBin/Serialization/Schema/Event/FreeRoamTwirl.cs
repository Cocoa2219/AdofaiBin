using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.FreeRoamTwirl, "FreeRoamTwirl", false, true)]
public sealed class FreeRoamTwirl : EventBase
{
    public Vec2 Position { get; set; } = new Vec2(1, 0);
}