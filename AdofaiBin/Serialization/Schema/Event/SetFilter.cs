using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetFilter, "SetFilter", false, false)]
public sealed class SetFilter : EventBase
{
    public Filter Filter { get; set; } = Filter.Grayscale;
    public bool Enabled { get; set; } = true;
    public float Intensity { get; set; } = 100;
    public float Duration { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public bool DisableOthers { get; set; } = false;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}