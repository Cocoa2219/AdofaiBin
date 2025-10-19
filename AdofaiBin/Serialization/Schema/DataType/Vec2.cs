namespace AdofaiBin.Serialization.Schema.DataType
{
    public readonly struct Vec2
    {
        public static readonly Vec2 Zero = new(0f, 0f);

        public readonly float X, Y;
        public Vec2(float x, float y) { X = x; Y = y; }
    }
}