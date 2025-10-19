using System;

namespace AdofaiBin.Serialization.Encoding.IO;

public interface IBinarySink : IDisposable
{
    long Position { get; }
    void Write(byte[] buffer, int offset, int count);
    void Flush();
    bool LeaveOpen { get; }
}
