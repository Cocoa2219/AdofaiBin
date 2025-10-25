using System;

namespace AdofaiBin.Serialization.Encoding.IO;

/// <summary>
/// A sink wrapper that forwards writes to an inner sink while updating a running CRC32 over the written bytes.
/// Disposing this wrapper does not dispose the inner sink.
/// </summary>
public sealed class Crc32BinarySink : IBinarySink
{
    private readonly IBinarySink _inner;
    private readonly Crc32 _crc;

    public Crc32BinarySink(IBinarySink inner, Crc32 crc)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _crc = crc ?? throw new ArgumentNullException(nameof(crc));
    }

    public long Position => _inner.Position;

    public bool LeaveOpen => true;

    public void Write(byte[] buffer, int offset, int count)
    {
        if (buffer == null) throw new ArgumentNullException(nameof(buffer));
        if (offset < 0 || count < 0 || offset + count > buffer.Length) throw new ArgumentOutOfRangeException();
        _inner.Write(buffer, offset, count);
        _crc.Update(buffer, offset, count);
    }

    public void Flush() => _inner.Flush();

    public void Dispose()
    {
        // Do not dispose the inner sink. This wrapper is scoped to the payload only.
    }
}
