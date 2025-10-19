using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetFilterAdvanced : EventBase
{
    public SetFilterAdvanced() : base("SetFilterAdvanced", false, false) { }

    public string Filter { get; set; } = "CameraFilterPack_AAA_SuperComputer";
    public bool Enabled { get; set; } = true;
    public bool DisableOthers { get; set; } = false;
    public float Duration { get; set; } = 0;
    public Ease Ease { get; set; } = Ease.Linear;
    public FilterTargetType TargetType { get; set; } = FilterTargetType.Camera;
    public FilterPlane Plane { get; set; } = FilterPlane.Foreground;
    public string TargetTag { get; set; }
    public string FilterProperties { get; set; }
    public float PropertiesTemplate { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}