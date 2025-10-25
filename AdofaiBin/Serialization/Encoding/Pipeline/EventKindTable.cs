using System;
using System.Collections.Generic;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class EventKindTable
{
    private readonly Dictionary<EventType, ushort> _map = new(new EventTypeComparer());
    private ushort _next = 1;

    public ushort GetOrAdd(EventType eventType)
    {
        if (_map.TryGetValue(eventType, out var id)) return id;
        id = _next++;
        _map[eventType] = id;
        return id;
    }

    public IDictionary<EventType, ushort> Items => _map;
}