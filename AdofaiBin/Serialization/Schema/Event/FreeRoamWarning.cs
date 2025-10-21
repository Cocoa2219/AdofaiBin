using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.FreeRoamWarning, "FreeRoamWarning", false, true)]
public sealed class FreeRoamWarning : EventBase
{
    public Vec2 Position { get; set; } = new Vec2(1, 0);
}