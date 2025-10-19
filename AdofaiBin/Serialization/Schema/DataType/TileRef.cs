namespace AdofaiBin.Serialization.Schema.DataType
{
    public enum TileRelativeTo : byte { ThisTile, Start, End }

    public readonly struct TileRef
    {
        public readonly int Index;
        public readonly TileRelativeTo RelativeTo;
        public TileRef(int index, TileRelativeTo rel) { Index = index; RelativeTo = rel; }
        public TileRef() { Index = 0; RelativeTo = TileRelativeTo.ThisTile; }
    }
}