using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class FreeRoamRemove : EventBase
{
    public FreeRoamRemove() : base("FreeRoamRemove", false, true) { }

    public Vec2 Position { get; set; } = new Vec2(1, 0);
    public Vec2 Size { get; set; } = new Vec2(1, 1);
}