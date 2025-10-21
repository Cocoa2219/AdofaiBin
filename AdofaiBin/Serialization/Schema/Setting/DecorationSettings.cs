using System.Collections.Generic;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.DecorationSettings, "DecorationSettings", false, false)]
public sealed class DecorationSettings : SettingBase
{
    public DecorationListFilter Filter { get; set; }
    public List<object> Decorations { get; set; } = new();
}