using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetFilter : EventBase
{
    public SetFilter() : base("SetFilter", false, false) { }

    public Filter Filter { get; set; } = Filter.Grayscale;
    public bool Enabled { get; set; } = true;
    public float Intensity { get; set; } = 100;
    public float Duration { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public bool DisableOthers { get; set; } = false;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}