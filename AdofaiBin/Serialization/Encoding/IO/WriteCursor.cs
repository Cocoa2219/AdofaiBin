using System;
using AdofaiBin.Serialization.Schema.DataType;

namespace AdofaiBin.Serialization.Encoding.IO;

public struct WriteCursor
{
    private readonly IBinarySink _sink;
    private readonly byte[] _scratch;

    public WriteCursor(IBinarySink sink)
    {
        _sink = sink;
        _scratch = new byte[16];
    }

    public long Position => _sink.Position;

    public void WriteByte(byte b)
    {
        _scratch[0] = b;
        _sink.Write(_scratch, 0, 1);
    }

    public void WriteBool(bool v)
    {
        WriteByte(v ? (byte)1 : (byte)0);
    }

    public void WriteBytes(byte[] data)
    {
        _sink.Write(data, 0, data.Length);
    }

    public void WriteBytes(ArraySegment<byte> seg)
    {
        _sink.Write(seg.Array!, seg.Offset, seg.Count);
    }

    public void WriteUInt32(uint v)
    {
        _scratch[0] = (byte)v;
        _scratch[1] = (byte)(v >> 8);
        _scratch[2] = (byte)(v >> 16);
        _scratch[3] = (byte)(v >> 24);
        _sink.Write(_scratch, 0, 4);
    }

    public void WriteInt32(int v)
    {
        WriteUInt32(unchecked((uint)v));
    }

    public void WriteVarUInt(ulong value)
    {
        while (value >= 0x80)
        {
            WriteByte((byte)(value | 0x80));
            value >>= 7;
        }

        WriteByte((byte)value);
    }

    public void WriteVarInt(long value)
    {
        var zz = ZigZagEncode(value);
        WriteVarUInt(zz);
    }

    public void WriteFloat(float f)
    {
        var bytes = BitConverter.GetBytes(f);
        if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
        _sink.Write(bytes, 0, 4);
    }

    public void WriteUtf8String(string s)
    {
        if (s == null)
        {
            WriteVarUInt(0);
            return;
        }

        var bytes = System.Text.Encoding.UTF8.GetBytes(s);
        WriteVarUInt((ulong)bytes.Length);
        _sink.Write(bytes, 0, bytes.Length);
    }

    public static ulong ZigZagEncode(long v)
    {
        return unchecked((ulong)((v << 1) ^ (v >> 63)));
    }

    public static long ZigZagDecode(ulong v)
    {
        return unchecked((long)((v >> 1) ^ (~(v & 1) + 1)));
    }
}

public static class WriteCursorExtensions
{
    public static void WriteColor(this ref WriteCursor cursor, Color32? color)
    {
        var c = color ?? new Color32(255, 0, 0, 0);

        cursor.WriteByte(c.A);
        cursor.WriteByte(c.R);
        cursor.WriteByte(c.G);
        cursor.WriteByte(c.B);
    }

    public static void WriteVec2(this ref WriteCursor cursor, Vec2? vec)
    {
        var vector = vec ?? new Vec2(0, 0);
        cursor.WriteFloat(vector.X);
        cursor.WriteFloat(vector.Y);
    }
}