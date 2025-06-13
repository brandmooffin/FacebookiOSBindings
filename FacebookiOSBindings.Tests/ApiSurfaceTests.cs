using System.Reflection;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FacebookiOSBindings.Tests;

/// <summary>
/// Tests the API surface of the Facebook iOS Bindings.
/// These tests verify that the bindings are correctly defined and can be instantiated.
/// </summary>
public class ApiSurfaceTests
{
    [Fact]
    [Trait("Category", TestCategories.RequiresActualSDK)]
    public void ApplicationDelegate_Should_Be_Instantiable()
    {
        // This verifies that the binding for FBSDKApplicationDelegate is correctly defined
        var delegateType = typeof(FacebookiOSBindings.FBSDKApplicationDelegate);
        var sharedInstanceProperty = delegateType.GetProperty("SharedInstance", BindingFlags.Public | BindingFlags.Static);
        Assert.NotNull(sharedInstanceProperty);
    }

    [Fact]
    [Trait("Category", TestCategories.ApiSurfaceTest)]
    public void LoginManager_Should_Be_Instantiable()
    {
        // This verifies that the binding for FBSDKLoginManager is correctly defined
        var loginManagerType = typeof(FacebookiOSBindings.LoginManager);
        var constructor = loginManagerType.GetConstructor(Type.EmptyTypes);
        Assert.NotNull(constructor);
    }

    [Fact]
    [Trait("Category", TestCategories.ApiSurfaceTest)]
    public void LoginManager_Should_Have_LogOut_Method()
    {
        // This verifies that the LogOut method is correctly bound
        var loginManagerType = typeof(FacebookiOSBindings.LoginManager);
        var logOutMethod = loginManagerType.GetMethod("LogOut");
        Assert.NotNull(logOutMethod);
    }

    [Fact]
    [Trait("Category", TestCategories.BindingStructureTest)]
    public void Profile_Should_Have_Expected_Properties()
    {
        // This is primarily a compilation test to verify the bindings
        // Actual functionality would require Facebook initialization
        var profileType = typeof(FacebookiOSBindings.Profile);
        
        // Ensure static methods and properties are bound correctly
        Assert.NotNull(profileType.GetProperty("CurrentProfile", BindingFlags.Public | BindingFlags.Static));
        Assert.NotNull(profileType.GetMethod("EnableUpdatesOnAccessTokenChange", BindingFlags.Public | BindingFlags.Static));
        
        // Verify property bindings
        Assert.NotNull(profileType.GetProperty("UserId"));
        Assert.NotNull(profileType.GetProperty("FirstName"));
        Assert.NotNull(profileType.GetProperty("LastName"));
    }

    [Fact]
    [Trait("Category", TestCategories.BindingStructureTest)]
    public void Settings_Should_Have_DisplayName_Property()
    {
        // Verify the DisplayName property is correctly bound
        var settingsType = typeof(FacebookiOSBindings.Settings);
        Assert.NotNull(settingsType.GetProperty("DisplayName", BindingFlags.Public | BindingFlags.Static));
    }
}
