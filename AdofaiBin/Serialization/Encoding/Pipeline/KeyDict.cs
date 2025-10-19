using System;
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class KeyDict
{
    private readonly Dictionary<string, int> _map = new Dictionary<string, int>(StringComparer.Ordinal);
    private int _next = 1;

    public int GetOrAdd(string key)
    {
        if (_map.TryGetValue(key, out var id)) return id;
        id = _next++;
        _map[key] = id;
        return id;
    }

    public IDictionary<string, int> Items => _map;
}