#nullable enable
using System;
using AdofaiBin.Serialization.Encoding.IO;
using AdofaiBin.Serialization.Schema;

namespace AdofaiBin.Serialization.Encoding.Pipeline;

public interface IPropertyEncoder
{
    Type[] Handles { get; }
    void Write(ref WriteCursor cursor, object? value);
}