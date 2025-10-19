using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class ShakeScreen : EventBase
{
    public ShakeScreen() : base("ShakeScreen", false, false) { }

    public float Duration { get; set; } = 1;
    public float Strength { get; set; } = 100;
    public float Intensity { get; set; } = 100;
    public Ease Ease { get; set; } = Ease.Linear;
    public bool FadeOut { get; set; } = true;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}