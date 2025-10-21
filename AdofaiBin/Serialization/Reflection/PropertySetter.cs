using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AdofaiBin.Serialization.Reflection;

public sealed class PropertySetter
{
    public Action<object, object> Set { get; }

    public PropertySetter(PropertyInfo propertyInfo)
    {
        var objectParameter = Expression.Parameter(typeof(object), "obj");
        var valueParameter = Expression.Parameter(typeof(object), "value");
        var castedObject = Expression.Convert(objectParameter, propertyInfo.DeclaringType!);
        var castedValue = Expression.Convert(valueParameter, propertyInfo.PropertyType);
        var body = Expression.Assign(Expression.Property(castedObject, propertyInfo), castedValue);
        var lambda = Expression.Lambda<Action<object, object>>(body, objectParameter, valueParameter);

        Set = lambda.Compile();
    }
}