#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Encoding.Pipeline;
using AdofaiBin.Serialization.Schema;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Encoding;

public sealed class EncodingContext(EncodingOptions options, IBinarySink sink, JObject rootJson, PropertyEncoderRegistry? propertyEncoderRegistry = null)
    : IDisposable
{
    public EncodingOptions Options { get; set; } = options ?? throw new ArgumentNullException(nameof(options));
    public IBinarySink Sink { get; set; } = sink ?? throw new ArgumentNullException(nameof(sink));
    public JObject RootJson { get; set; } = rootJson ?? throw new ArgumentNullException(nameof(rootJson));
    public PropertyEncoderRegistry Encoders { get; set; } = propertyEncoderRegistry ?? new PropertyEncoderRegistry(PropertyEncoderRegistry.AllEncoders);

    public LevelSchema Model { get; set; } = new();
    public StringTable Strings { get; private set; } = new();
    public EventKindTable EventKinds { get; private set; } = new();
    public KeyDict KeyDict { get; private set; } = new();
    public EncodingStats Stats { get; private set; } = new();

    public void Dispose()
    {
        Sink.Flush();
        Sink.Dispose();
    }
}