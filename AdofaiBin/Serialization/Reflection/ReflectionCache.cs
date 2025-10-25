#nullable enable
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace AdofaiBin.Serialization.Reflection;

public static class ReflectionCache
{
    private static readonly ConcurrentDictionary<string, Type> _typeByName =
        new(StringComparer.OrdinalIgnoreCase);

    private static readonly ConcurrentDictionary<Type, Dictionary<string, (PropertyInfo info, PropertySetter setter)>> _propsByType =
        new();

    public static Type GetTypeByName(string name, Func<string, Type> resolver)
    {
        return _typeByName.GetOrAdd(name, resolver);
    }

    public static bool TryGetTypeByName(string name, out Type? type)
    {
        return _typeByName.TryGetValue(name, out type);
    }

    public static Dictionary<string, (PropertyInfo info, PropertySetter setter)> GetProps(Type t)
    {
        return _propsByType.GetOrAdd(t, key =>
        {
            var map = new Dictionary<string, (PropertyInfo info, PropertySetter setter)>(StringComparer.OrdinalIgnoreCase);
            foreach (var p in key.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                map[p.Name] = (p, new PropertySetter(p));
            return map;
        });
    }

    public static PropertySetter GetPropertySetter(Type t, string propertyName)
    {
        var props = GetProps(t);
        if (props.TryGetValue(propertyName, out var tuple))
            return tuple.setter;
        throw new KeyNotFoundException($"Property '{propertyName}' not found on type '{t.FullName}'.");
    }

    public static bool TryGetPropertySetter(Type t, string propertyName, out PropertySetter? setter)
    {
        var props = GetProps(t);
        if (props.TryGetValue(propertyName, out var tuple))
        {
            setter = tuple.setter;
            return true;
        }
        setter = null;
        return false;
    }

    public static PropertyInfo GetPropertyInfo(Type t, string propertyName)
    {
        var props = GetProps(t);
        if (props.TryGetValue(propertyName, out var tuple))
            return tuple.info;
        throw new KeyNotFoundException($"Property '{propertyName}' not found on type '{t.FullName}'.");
    }

    public static bool TryGetPropertyInfo(Type t, string propertyName, out PropertyInfo? info)
    {
        var props = GetProps(t);
        if (props.TryGetValue(propertyName, out var tuple))
        {
            info = tuple.info;
            return true;
        }
        info = null;
        return false;
    }

    public static void SetProperty(object obj, string propertyName, object? value)
    {
        var t = obj.GetType();
        var setter = GetPropertySetter(t, propertyName);
        setter.Set(obj, value);
    }

    public static void Clear()
    {
        _typeByName.Clear();
        _propsByType.Clear();
    }
}