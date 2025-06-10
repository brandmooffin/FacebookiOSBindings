using System.Reflection;
using FacebookiOSBindings.Tests.Helpers;

namespace FacebookiOSBindings.Tests;

/// <summary>
/// Tests that verify all expected bindings exist in the assembly
/// </summary>
public class BindingCompletionTests
{
    // List of expected bound types from Facebook SDK
    private static readonly string[] ExpectedTypes = new[]
    {
        "FBSDKApplicationDelegate",
        "FBAEMReporter",
        "LoginManager",
        "LoginManagerLoginResult",
        "AccessToken",
        "Profile",
        "Settings"
    };
    
    // Dictionary of expected properties for each type
    private static readonly Dictionary<string, string[]> ExpectedProperties = new()
    {
        ["FBSDKApplicationDelegate"] = new[] { "SharedInstance" },
        ["AccessToken"] = new[] { "CurrentAccessToken", "UserID" },
        ["Profile"] = new[] { "CurrentProfile", "UserId", "FirstName", "LastName" },
        ["LoginManagerLoginResult"] = new[] { "IsCancelled", "Token" },
        ["Settings"] = new[] { "DisplayName" }
    };
    
    // Dictionary of expected methods for each type
    private static readonly Dictionary<string, string[]> ExpectedMethods = new()
    {
        ["FBSDKApplicationDelegate"] = new[] { "FinishedLaunching", "OpenUrl" },
        ["FBAEMReporter"] = new[] { "Enable" },
        ["LoginManager"] = new[] { "LogIn", "LogOut" },
        ["Profile"] = new[] { "EnableUpdatesOnAccessTokenChange", "RequestProfileForCurrentAccessToken" }
    };
    
    [Fact]
    [Trait("Category", TestCategories.BindingStructureTest)]
    public void All_Expected_Types_Should_Be_Bound()
    {
        foreach (var typeName in ExpectedTypes)
        {
            // This will throw if the type doesn't exist
            var type = GetTypeFromBindings(typeName);
            Assert.NotNull(type);
        }
    }
    
    [Fact]
    [Trait("Category", TestCategories.BindingStructureTest)]
    public void All_Expected_Properties_Should_Be_Bound()
    {
        foreach (var typeEntry in ExpectedProperties)
        {
            var type = GetTypeFromBindings(typeEntry.Key);
            
            foreach (var propertyName in typeEntry.Value)
            {
                // Try both static and instance bindings
                var property = type.GetProperty(propertyName, 
                    BindingFlags.Public | BindingFlags.Static | 
                    BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                    
                Assert.NotNull(property);
            }
        }
    }
    
    [Fact]
    [Trait("Category", TestCategories.BindingStructureTest)]
    public void All_Expected_Methods_Should_Be_Bound()
    {
        foreach (var typeEntry in ExpectedMethods)
        {
            var type = GetTypeFromBindings(typeEntry.Key);
            
            foreach (var methodName in typeEntry.Value)
            {
                // Try both static and instance bindings
                var method = type.GetMethod(methodName,
                    BindingFlags.Public | BindingFlags.Static | 
                    BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                    
                Assert.NotNull(method);
            }
        }
    }
    
    private Type GetTypeFromBindings(string typeName)
    {
        var assembly = typeof(FacebookiOSBindings.FBSDKApplicationDelegate).Assembly;
        return assembly.GetType($"FacebookiOSBindings.{typeName}");
    }
}
