using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetFloorIcon : EventBase
{
    public SetFloorIcon() : base("SetFloorIcon", false, false) { }

    public CustomFloorIcon Icon { get; set; } = CustomFloorIcon.None;
}