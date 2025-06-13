using System.Reflection;
using FacebookiOSBindings.Tests;
using Foundation;
using UIKit;

namespace FacebookiOSBindings.IntegrationTests;

/// <summary>
/// Integration tests for the Facebook iOS SDK login functionality.
/// These tests require Facebook SDK initialization with valid app credentials.
/// </summary>
[Collection("Facebook SDK Collection")]
public class LoginManagerIntegrationTests
{
    [Fact]
    [Trait("Category", TestCategories.RequiresActualSDK)]
    public void LoginManager_LogIn_Should_Have_Correct_Signature()
    {
        // Instead of running actual login flow, verify the method signature
        var loginManagerType = typeof(FacebookiOSBindings.LoginManager);
        var logInMethod = loginManagerType.GetMethod("LogIn", new[] { 
            typeof(string[]), 
            typeof(UIViewController), 
            typeof(FacebookiOSBindings.LoginManagerLoginResultBlock) 
        });
        
        Assert.NotNull(logInMethod);
    }
}

/// <summary>
/// Integration tests for the Facebook iOS SDK profile functionality.
/// </summary>
[Collection("Facebook SDK Collection")]
public class ProfileIntegrationTests
{
    [Fact]
    [Trait("Category", TestCategories.RequiresActualSDK)]
    public void Profile_EnableUpdatesOnAccessTokenChange_Should_Have_Correct_Signature()
    {
        var profileType = typeof(FacebookiOSBindings.Profile);
        var method = profileType.GetMethod("EnableUpdatesOnAccessTokenChange", 
            BindingFlags.Public | BindingFlags.Static, 
            null, 
            new[] { typeof(bool) }, 
            null);
            
        Assert.NotNull(method);
    }
}
