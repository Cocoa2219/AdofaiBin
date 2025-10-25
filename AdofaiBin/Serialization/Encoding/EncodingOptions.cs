namespace AdofaiBin.Serialization.Encoding
{
    public sealed class EncodingOptions
    {
        // public BinaryVersion Version { get; set; } = BinaryVersion.V1;

        public bool Validate { get; set; } = true;
        public bool LeaveOpen { get; set; } = false;
        public CompressionKind Compression { get; set; } = CompressionKind.None;
        public int FloatPrecision { get; set; } = 4;
        public bool Deterministic { get; set; } = true;
        public uint HeaderFlags { get; set; } = 0;
    }

    public enum BinaryVersion : byte
    {
        V1 = 1,
    }

    public enum CompressionKind : byte
    {
        None = 0,
        Gzip = 1,
        Zlib = 2,
        Lz4 = 3,
    }
}