using AdofaiBin.Serialization.Schema.DataType;
using AdofaiBin.Serialization.Schema.Event.Enum;

namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetParticle : EventBase
{
    public SetParticle() : base("SetParticle", false, false) { }

    public float Duration { get; set; } = 1;
    public string Tag { get; set; } = "editor.placeholder.sampleTag";
    public ParticlePlayMode TargetMode { get; set; } = ParticlePlayMode.Start;
    public string EventTag { get; set; }
    public MinMaxGradient Color { get; set; } = new MinMaxGradient { Mode = GradientMode.Color, ColorMin = new Color32(255, 255, 255, 255) };
    public FloatPair VelocityLimitOverLifetime { get; set; } = new FloatPair(0, 0);
    public MinMaxGradient ColorOverLifetime { get; set; } = new MinMaxGradient { Mode = GradientMode.Color, ColorMin = new Color32(255, 255, 255, 255) };
    public FloatPair SizeOverLifetime { get; set; } = new FloatPair(100, 100);
    public int MaxParticles { get; set; } = 1000;
    public FloatPair ParticleLifetime { get; set; } = new FloatPair(10, 10);
    public FloatPair ParticleSize { get; set; } = new FloatPair(100, 100);
    public Vec2Range Velocity { get; set; } = new Vec2Range(new Vec2(0, 0), new Vec2(0, 0));
    public FloatPair RotationOverTime { get; set; } = new FloatPair(0, 0);
    public ParticleShape ShapeType { get; set; } = ParticleShape.Circle;
    public float ShapeRadius { get; set; } = 1;
    public float Arc { get; set; } = 360;
    public ParticleArcMode ArcMode { get; set; } = ParticleArcMode.Random;
    public int EmissionRate { get; set; } = 10;
    public float SimulationSpeed { get; set; } = 100;
    public float AngleOffset { get; set; } = 0;
    public bool LockRotation { get; set; } = false;
    public bool LockScale { get; set; } = false;
    public Ease Ease { get; set; } = Ease.Linear;
}