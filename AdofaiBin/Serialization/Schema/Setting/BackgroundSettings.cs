using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.BackgroundSettings, "BackgroundSettings", false, false)]
public sealed class BackgroundSettings : SettingBase
{
    public Color32 BackgroundColor { get; set; } = new Color32(0, 0, 0, 255);
    public bool ShowDefaultBGIfNoImage { get; set; } = true;
    public bool ShowDefaultBGTile { get; set; } = true;
    public Color32 DefaultBGTileColor { get; set; } = new Color32(16, 17, 33, 255);
    public BGShapeType DefaultBGShapeType { get; set; } = BGShapeType.Default;
    public Color32 DefaultBGShapeColor { get; set; } = new Color32(255, 255, 255, 255);
    public string BgImage { get; set; } = "";
    public Color32 BgImageColor { get; set; } = new Color32(255, 255, 255, 255);
    public Vec2 Parallax { get; set; } = new Vec2(100, 100);
    public BgDisplayMode BgDisplayMode { get; set; } = BgDisplayMode.FitToScreen;
    public bool ImageSmoothing { get; set; } = true;
    public bool LockRot { get; set; } = false;
    public bool LoopBG { get; set; } = false;
    public int ScalingRatio { get; set; } = 100;
}