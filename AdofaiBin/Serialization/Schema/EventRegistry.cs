using System;
using System.Collections.Generic;
using System.Reflection;
using AdofaiBin.Serialization.Schema.Event;

namespace AdofaiBin.Serialization.Schema;

public static class EventRegistry
{
    private static Dictionary<EventType, Type> _eventTypeMap;
    private static Dictionary<EventType, EventAttribute> _eventAttributes;

    public static IReadOnlyDictionary<EventType, Type> EventTypeMap
    {
        get
        {
            if (_eventTypeMap == null)
            {
                LazyInitialize();
            }

            return _eventTypeMap;
        }
    }

    public static IReadOnlyDictionary<EventType, EventAttribute> EventAttributes
    {
        get
        {
            if (_eventAttributes == null)
            {
                LazyInitialize();
            }

            return _eventAttributes;
        }
    }

    public static Type GetEventType(EventType eventType)
    {
        LazyInitialize();

        if (EventTypeMap.TryGetValue(eventType, out var type))
        {
            return type;
        }

        throw new ArgumentException($"Event type {eventType} is not registered.", nameof(eventType));
    }

    public static EventAttribute GetEventAttribute(EventType eventType)
    {
        LazyInitialize();

        if (EventAttributes.TryGetValue(eventType, out var attribute))
        {
            return attribute;
        }

        throw new ArgumentException($"Event type {eventType} is not registered.", nameof(eventType));
    }

    private static void LazyInitialize()
    {
        if (_eventTypeMap != null)
            return;

        _eventTypeMap = new Dictionary<EventType, Type>();
        _eventAttributes = new Dictionary<EventType, EventAttribute>();
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var t in types)
        {
            if (!(t is { IsClass: true, IsAbstract: false } && typeof(EventBase).IsAssignableFrom(t)))
                continue;

            if (!Attribute.IsDefined(t, typeof(EventAttribute), false))
                continue;

            var data = t.GetCustomAttribute<EventAttribute>(false);

            if (data != null)
            {
                var eventType = data.EventType;
                _eventTypeMap[eventType] = t;
                _eventAttributes[eventType] = data;
            }
        }
    }
}