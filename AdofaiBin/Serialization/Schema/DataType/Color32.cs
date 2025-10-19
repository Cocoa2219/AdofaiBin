namespace AdofaiBin.Serialization.Schema.DataType
{
    public readonly struct Color32
    {
        public readonly byte A, R, G, B;
        public Color32(byte a, byte r, byte g, byte b) { A = a; R = r; G = g; B = b; }
        public static Color32 FromRgb(byte r, byte g, byte b) => new(255, r, g, b);
        public uint ToUInt32ARGB() => (uint)(A << 24 | R << 16 | G << 8 | B);
        public static Color32 FromUInt32ARGB(uint v) => new(
            (byte)(v >> 24), (byte)(v >> 16), (byte)(v >> 8), (byte)v);
    }
}