using System;
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class EventKindTable
{
    private readonly Dictionary<string, ushort> _map = new Dictionary<string, ushort>(StringComparer.Ordinal);
    private ushort _next = 1;

    public ushort GetOrAdd(string eventType)
    {
        if (_map.TryGetValue(eventType, out var id)) return id;
        id = _next++;
        _map[eventType] = id;
        return id;
    }

    public IDictionary<string, ushort> Items => _map;
}