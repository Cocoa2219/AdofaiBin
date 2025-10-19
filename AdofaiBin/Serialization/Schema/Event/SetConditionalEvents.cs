namespace AdofaiBin.Serialization.Schema.Event;

public sealed class SetConditionalEvents : EventBase
{
    public SetConditionalEvents() : base("SetConditionalEvents", false, false) { }

    public string PerfectTag { get; set; } = "NONE";
    public string HitTag { get; set; } = "NONE";
    public string EarlyPerfectTag { get; set; } = "NONE";
    public string LatePerfectTag { get; set; } = "NONE";
    public string BarelyTag { get; set; } = "NONE";
    public string VeryEarlyTag { get; set; } = "NONE";
    public string VeryLateTag { get; set; } = "NONE";
    public string MissTag { get; set; } = "NONE";
    public string TooEarlyTag { get; set; } = "NONE";
    public string TooLateTag { get; set; } = "NONE";
    public string LossTag { get; set; } = "NONE";
    public string OnCheckpointTag { get; set; } = "NONE";
}