using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Setting;

[Event(EventType.CameraSettings, "CameraSettings", false, false)]
public sealed class CameraSettings : SettingBase
{
    public CamMovementType RelativeTo { get; set; } = CamMovementType.Player;
    public Vec2 Position { get; set; } = new Vec2(0, 0);
    public float Rotation { get; set; } = 0;
    public float Zoom { get; set; } = 100;
    public bool PulseOnFloor { get; set; } = true;
    public bool StartCamLowVFX { get; set; } = false;
}