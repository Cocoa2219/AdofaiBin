using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ScreenScroll : EventBase
{
    public ScreenScroll() : base("ScreenScroll", false, false) { }

    public Vec2 Scroll { get; set; } = new Vec2(0, 0);
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}