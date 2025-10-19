using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class Flash : EventBase
{
    public Flash() : base("Flash", false, false) { }

    public float Duration { get; set; } = 1;
    public FlashPlane Plane { get; set; } = FlashPlane.Background;
    public Color32 StartColor { get; set; } = new Color32(255, 255, 255, 255);
    public float StartOpacity { get; set; } = 100;
    public Color32 EndColor { get; set; } = new Color32(255, 255, 255, 255);
    public float EndOpacity { get; set; } = 0;
    public float AngleOffset { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public string EventTag { get; set; }
}