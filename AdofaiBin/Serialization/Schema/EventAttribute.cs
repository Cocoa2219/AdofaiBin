using System;

namespace AdofaiBin.Serialization.Schema;

public class EventAttribute(EventType eventType, string name, bool isDecoration, bool taroDlc)
    : Attribute
{
    public EventType EventType { get; } = eventType;
    public string Name { get; } = name;
    public bool IsDecoration { get; } = isDecoration;
    public bool TaroDLC { get; } = taroDlc;
}