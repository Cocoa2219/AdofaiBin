using System;
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class KeyDict
{
    private readonly Dictionary<string, uint> _map = new Dictionary<string, uint>(StringComparer.Ordinal);
    private uint _next = 1;

    public uint GetOrAdd(string key)
    {
        if (_map.TryGetValue(key, out var id)) return id;
        id = _next++;
        _map[key] = id;
        return id;
    }

    public IDictionary<string, uint> Items => _map;
}