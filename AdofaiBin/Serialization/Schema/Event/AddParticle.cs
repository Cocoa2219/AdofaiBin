using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

[Event(EventType.AddParticle, "AddParticle", true, false)]
public sealed class AddParticle : EventBase
{
    public object PlaybackControl { get; set; }
    public string Tag { get; set; }
    public string DecorationImage { get; set; } = "";
    public Vec2 RandomTextureTiling { get; set; } = new(1, 1);
    public ParticleSimulationSpace SimulationSpace { get; set; } = ParticleSimulationSpace.Local;
    public FloatPair StartRotation { get; set; } = new(0, 0);public MinMaxGradient Color { get; set; } =
        new() { Mode = GradientMode.Color, ColorMin = new Color32(255, 255, 255, 255) };public FloatPair VelocityLimitOverLifetime { get; set; } = new(0, 0);public MinMaxGradient ColorOverLifetime { get; set; } = new()
        { Mode = GradientMode.Color, ColorMin = new Color32(255, 255, 255, 255) };public FloatPair SizeOverLifetime { get; set; } = new(100, 100);
    public int MaxParticles { get; set; } = 1000;
    public bool AutoPlay { get; set; } = true;
    public float PlayDuration { get; set; } = 5;
    public bool Loop { get; set; } = true;
    public FloatPair ParticleLifetime { get; set; } = new(10, 10);
    public FloatPair ParticleSize { get; set; } = new(100, 100);
    public Vec2Range Velocity { get; set; } = new(new Vec2(0, 0), new Vec2(0, 0));
    public FloatPair RotationOverTime { get; set; } = new(0, 0);
    public ParticleShape ShapeType { get; set; } = ParticleShape.Circle;
    public float ShapeRadius { get; set; } = 1;
    public float Arc { get; set; } = 360;
    public ParticleArcMode ArcMode { get; set; } = ParticleArcMode.Random;
    public FloatPair EmissionRate { get; set; } = new(10, 10);
    public float SimulationSpeed { get; set; } = 100;
    public int RandomSeed { get; set; } = 0;
    public Vec2 Position { get; set; } = new(0, 0);
    public DecPlacementType RelativeTo { get; set; } = DecPlacementType.Global;
    public int Floor { get; set; } = 0;
    public Vec2 PivotOffset { get; set; } = new(0, 0);
    public float Rotation { get; set; } = 0;
    public Vec2 Scale { get; set; } = new(100, 100);
    public int Depth { get; set; } = -1;
    public Vec2 Parallax { get; set; } = new(0, 0);
    public Vec2 ParallaxOffset { get; set; } = new(0, 0);
    public bool LockRotation { get; set; } = false;
    public bool LockScale { get; set; } = false;
}