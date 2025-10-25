using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline.Stage;

public class BuildTablesStage : IStage<EncodingContext>
{
    /// <inheritdoc />
    public ValueTask RunAsync(EncodingContext context, CancellationToken ct)
    {
        var model = context.Model;
        var eventKinds = context.EventKinds;
        var keyDict = context.KeyDict;

        var comparer = new EventTypeComparer();
        var eventKindFreq = new Dictionary<EventType, int>(comparer);
        var keyFreq = new Dictionary<string, int>(StringComparer.Ordinal);

        foreach (var evt in model.Events)
        {
            eventKindFreq.TryGetValue(evt.Type, out var ekCount);
            eventKindFreq[evt.Type] = ekCount + 1;

            foreach (var key in evt.Event.RawProperties.Keys)
            {
                keyFreq.TryGetValue(key, out var kCount);
                keyFreq[key] = kCount + 1;
            }
        }

        foreach (var deco in model.Decorations)
        {
            eventKindFreq.TryGetValue(deco.Type, out var ekCount);
            eventKindFreq[deco.Type] = ekCount + 1;

            foreach (var key in deco.Event.RawProperties.Keys)
            {
                keyFreq.TryGetValue(key, out var kCount);
                keyFreq[key] = kCount + 1;
            }
        }

        var orderedEventKinds = context.Options.Deterministic
            ? eventKindFreq
                .OrderBy(kv => kv.Key) // EventType's natural order
                .Select(kv => kv.Key)
            : eventKindFreq
                .OrderByDescending(kv => kv.Value) // Frequency
                .ThenBy(kv => kv.Key) // EventType's natural order
                .Select(kv => kv.Key);

        foreach (var eventType in orderedEventKinds)
        {
            Console.WriteLine($"Adding event type to dict: {eventType}");
            eventKinds.GetOrAdd(eventType);
        }

        var orderedKeys = context.Options.Deterministic
            ? keyFreq
                .OrderBy(kv => kv.Key, StringComparer.Ordinal) // Alphabetical order
                .Select(kv => kv.Key)
            : keyFreq
                .OrderByDescending(kv => kv.Value) // Frequency
                .ThenBy(kv => kv.Key, StringComparer.Ordinal) // Alphabetical order
                .Select(kv => kv.Key);

        foreach (var key in orderedKeys)
        {
            Console.WriteLine($"Adding key to dict: {key}");
            keyDict.GetOrAdd(key);
        }

        return default;
    }
}