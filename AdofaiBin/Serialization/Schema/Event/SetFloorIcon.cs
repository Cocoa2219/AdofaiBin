using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.SetFloorIcon, "SetFloorIcon", false, false)]
public sealed class SetFloorIcon : EventBase
{
    public CustomFloorIcon Icon { get; set; } = CustomFloorIcon.None;
}