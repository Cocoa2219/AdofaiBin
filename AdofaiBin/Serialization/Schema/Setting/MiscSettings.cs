using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.MiscSettings, "MiscSettings", false, false)]
public sealed class MiscSettings : SettingBase
{
    public string BgVideo { get; set; } = "";
    public bool LoopVideo { get; set; } = false;
    public int VidOffset { get; set; } = 0;
    public bool FloorIconOutlines { get; set; } = false;
    public bool StickToFloors { get; set; } = true;
    public Ease PlanetEase { get; set; } = Ease.Linear;
    public int PlanetEaseParts { get; set; } = 1;
    public EasePartBehavior PlanetEasePartBehavior { get; set; } = EasePartBehavior.Mirror;
    public string CustomClass { get; set; }
    public EditorSelectTarget SelectTarget { get; set; } = EditorSelectTarget.Floor;
    public Color32 DefaultTextColor { get; set; } = new Color32(255, 255, 255, 255);
    public Color32 DefaultTextShadowColor { get; set; } = new Color32(0, 0, 0, 80);
    public string CongratsText { get; set; }
    public string PerfectText { get; set; }
}