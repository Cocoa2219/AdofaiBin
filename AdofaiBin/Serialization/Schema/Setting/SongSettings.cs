using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.SongSettings, "SongSettings", false, false)]
public sealed class SongSettings : SettingBase
{
    public string SongFilename { get; set; } = "";
    public float Bpm { get; set; } = 100;
    public int Volume { get; set; } = 100;
    public int Offset { get; set; } = 0;
    public int Pitch { get; set; } = 100;
    public HitSound Hitsound { get; set; } = HitSound.Kick;
    public int HitsoundVolume { get; set; } = 100;
    public int CountdownTicks { get; set; } = 4;
}