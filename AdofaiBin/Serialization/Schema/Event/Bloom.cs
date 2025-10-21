using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.Bloom, "Bloom", false, false)]
public sealed class Bloom : EventBase
{
    public bool Enabled { get; set; } = true;
    public float Threshold { get; set; } = 50;
    public float Intensity { get; set; } = 100;
    public Color32 Color { get; set; } = new Color32(255, 255, 255, 255);
    public float Duration { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}