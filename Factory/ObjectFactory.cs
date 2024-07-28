
using System;
using System.Collections.Generic;

public partial class ObjectFactory
{
    static ObjectFactory()
    {
        
    }
    private static Dictionary<string, Func<object>> typeRegistry = new Dictionary<string, Func<object>>();
    public static void Register(string typeName, Func<object> factoryMethod)
    {
        typeRegistry[typeName] = factoryMethod;
    }
    public static object Create(string typeName)
    {
        if (typeRegistry.TryGetValue(typeName, out var factoryMethod))
        {
            return factoryMethod();
        }
        return null; // Handle unknown type
    }
    public static T Create<T>(string typeName)
    {
        if (typeRegistry.TryGetValue(typeName, out var factoryMethod))
        {
            return (T)factoryMethod();
        }
        return default; // Handle unknown type
    }
}
