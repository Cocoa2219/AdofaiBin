#nullable enable
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Schema.Event;

public abstract class EventBase
{
    public EventAttribute Data { get; internal set; } = null!;
    public Dictionary<string, object?> RawProperties { get; } = new();
}
