using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class FreeRoamWarning : EventBase
{
    public FreeRoamWarning() : base("FreeRoamWarning", false, true) { }

    public Vec2 Position { get; set; } = new Vec2(1, 0);
}