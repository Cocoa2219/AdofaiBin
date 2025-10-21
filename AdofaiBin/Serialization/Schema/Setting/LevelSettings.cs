using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.LevelSettings, "LevelSettings", false, false)]
public sealed class LevelSettings : SettingBase
{
    public string Artist { get; set; }
    public SpecialArtistType SpecialArtistType { get; set; } = SpecialArtistType.None;
    public string ArtistPermission { get; set; } = "";
    public string Song { get; set; }
    public string Author { get; set; }
    public bool SeparateCountdownTime { get; set; } = true;
    public string PreviewImage { get; set; } = "";
    public string PreviewIcon { get; set; } = "";
    public Color32 PreviewIconColor { get; set; } = new Color32(0, 63, 82, 255);
    public int PreviewSongStart { get; set; } = 0;
    public int PreviewSongDuration { get; set; } = 10;
    public bool SeizureWarning { get; set; } = false;
    public string LevelDesc { get; set; }
    public string LevelTags { get; set; }
    public string ArtistLinks { get; set; }
    public float SpeedTrialAim { get; set; } = 0;
    public int Difficulty { get; set; } = 1;
    public object[] RequiredMods { get; set; } = new object[0];
}