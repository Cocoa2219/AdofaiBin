using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetInputEvent, "SetInputEvent", false, false)]
public sealed class SetInputEvent : EventBase
{
    public InputEventTarget Target { get; set; } = InputEventTarget.Any;
    public InputEventState State { get; set; } = InputEventState.Down;
    public bool IgnoreInput { get; set; } = false;
    public string TargetEventTag { get; set; } = "NONE";
    public float AngleOffset { get; set; } = 0;
    public string EventTag { get; set; }
}