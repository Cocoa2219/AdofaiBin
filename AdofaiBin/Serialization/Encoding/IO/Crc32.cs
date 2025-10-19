namespace AdofaiBin.Serialization.Encoding.IO;

public sealed class Crc32
{
    private static readonly uint[] Table = Init();
    private uint _crc = 0xFFFFFFFFu;

    public void Update(byte[] buffer, int offset, int count)
    {
        for (var i = 0; i < count; i++)
        {
            var idx = (_crc ^ buffer[offset + i]) & 0xFF;
            _crc = Table[idx] ^ (_crc >> 8);
        }
    }

    public uint Value => _crc ^ 0xFFFFFFFFu;

    private static uint[] Init()
    {
        const uint poly = 0xEDB88320u;
        var table = new uint[256];
        for (uint i = 0; i < 256; i++)
        {
            var c = i;
            for (var k = 0; k < 8; k++)
                c = (c & 1) != 0 ? poly ^ (c >> 1) : c >> 1;
            table[i] = c;
        }

        return table;
    }

    public void Reset()
    {
        _crc = 0xFFFFFFFFu;
    }
}