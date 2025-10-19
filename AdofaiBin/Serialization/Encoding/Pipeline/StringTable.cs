using System;
using System.Collections.Generic;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public sealed class StringTable
{
    private readonly Dictionary<string, int> _toId = new(StringComparer.Ordinal);
    private readonly List<string> _items = new();

    public int GetOrAdd(string s)
    {
        s ??= string.Empty;
        if (_toId.TryGetValue(s, out var id)) return id;
        id = _items.Count;
        _items.Add(s);
        _toId.Add(s, id);
        return id;
    }

    public IList<string> Items => _items;
}