using System;
using AdofaiBin.Serialization.Encoding.Exception;
using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Misc;

public static class JObjectExtensions
{
    public static T GetRequired<T>(this JObject obj, string propertyName)
    {
        if (!obj.TryGetValue(propertyName, out var token))
        {
            throw new EncodingInvalidJsonException($"Missing required property '{propertyName}'.");
        }

        try
        {
            return token.Type == JTokenType.Null
                ? throw new EncodingInvalidJsonException($"Property '{propertyName}' is null but a value of type '{typeof(T).Name}' is required.")
                : token.Value<T>();
        }
        catch (Exception ex)
        {
            throw new EncodingInvalidJsonException($"Property '{propertyName}' could not be converted to type '{typeof(T).Name}': {ex.Message}");
        }
    }

    public static T GetOptional<T>(this JObject obj, string propertyName, T defaultValue)
    {
        if (!obj.TryGetValue(propertyName, out var token) || token.Type == JTokenType.Null)
        {
            return defaultValue;
        }

        try
        {
            return token.Value<T>();
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}