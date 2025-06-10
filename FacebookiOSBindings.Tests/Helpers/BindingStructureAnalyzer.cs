using System.Reflection;

namespace FacebookiOSBindings.Tests.Helpers;

/// <summary>
/// Helper class to analyze binding structure using reflection
/// </summary>
public static class BindingStructureAnalyzer
{
    /// <summary>
    /// Verifies that a type exists in the Facebook iOS bindings assembly
    /// </summary>
    /// <param name="typeName">The name of the type to check</param>
    /// <returns>The Type object if found</returns>
    public static Type GetBindingType(string typeName)
    {
        var assembly = typeof(FacebookiOSBindings.FBSDKApplicationDelegate).Assembly;
        var type = assembly.GetType($"FacebookiOSBindings.{typeName}");
        
        if (type == null)
        {
            throw new InvalidOperationException($"Type '{typeName}' not found in the bindings assembly");
        }
        
        return type;
    }
    
    /// <summary>
    /// Gets a method from a type with specific parameters
    /// </summary>
    /// <param name="type">The type to search</param>
    /// <param name="methodName">The name of the method</param>
    /// <param name="parameterTypes">The parameter types</param>
    /// <returns>The MethodInfo if found</returns>
    public static MethodInfo GetMethod(Type type, string methodName, Type[] parameterTypes = null)
    {
        if (parameterTypes == null)
        {
            return type.GetMethod(methodName);
        }
        
        return type.GetMethod(methodName, parameterTypes);
    }
    
    /// <summary>
    /// Gets a property from a type
    /// </summary>
    /// <param name="type">The type to search</param>
    /// <param name="propertyName">The name of the property</param>
    /// <param name="isStatic">Whether the property is static</param>
    /// <returns>The PropertyInfo if found</returns>
    public static PropertyInfo GetProperty(Type type, string propertyName, bool isStatic = false)
    {
        var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
        
        if (isStatic)
        {
            bindingFlags = BindingFlags.Public | BindingFlags.Static;
        }
        
        return type.GetProperty(propertyName, bindingFlags);
    }
}
