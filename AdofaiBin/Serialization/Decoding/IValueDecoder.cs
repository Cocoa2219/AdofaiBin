#nullable enable
using System;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Decoding;

internal interface IValueDecoder
{
    bool CanDecode(JTokenType tokenType, Type targetType);
    object? Decode(JToken token, Type targetType);
}

