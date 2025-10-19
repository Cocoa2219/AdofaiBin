using System;
using System.IO;

namespace AdofaiBin.Serialization.Encoding.IO;

public sealed class StreamBinarySink(Stream stream, bool leaveOpen) : IBinarySink
{
    private readonly Stream _stream = stream ?? throw new ArgumentNullException(nameof(stream));
    public bool LeaveOpen { get; private set; } = leaveOpen;

    public long Position => _stream.CanSeek ? _stream.Position : -1;

    public void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);
    public void Flush() => _stream.Flush();

    public void Dispose()
    {
        if (!LeaveOpen) _stream.Dispose();
    }

    public static StreamBinarySink FromStream(Stream s, bool leaveOpen) => new(s, leaveOpen);
}