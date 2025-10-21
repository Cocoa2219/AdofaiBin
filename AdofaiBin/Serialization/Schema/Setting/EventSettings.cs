using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.EventSettings, "EventSettings", false, false)]
public sealed class EventSettings : SettingBase
{
    public object Filter { get; set; }
    public List<object> Events { get; set; } = new();
}