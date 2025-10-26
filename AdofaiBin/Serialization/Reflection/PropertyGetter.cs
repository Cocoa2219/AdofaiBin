using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AdofaiBin.Serialization.Reflection;

public sealed class PropertyGetter
{
    public Func<object, object> Get { get; }

    public PropertyGetter(PropertyInfo propertyInfo)
    {
        var objectParameter = Expression.Parameter(typeof(object), "obj");

        var castedObject = Expression.Convert(objectParameter, propertyInfo.DeclaringType!);
        var propertyAccess = Expression.Property(castedObject, propertyInfo);
        var castedResult = Expression.Convert(propertyAccess, typeof(object));
        var lambda = Expression.Lambda<Func<object, object?>>(castedResult, objectParameter);
        Get = lambda.Compile();
    }
}