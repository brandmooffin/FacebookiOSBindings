# Facebook iOS SDK Bindings for .NET

This package provides C# bindings for the Facebook iOS SDK, enabling you to integrate Facebook functionality into your .NET iOS applications built with Xamarin.iOS or .NET MAUI.

## Included Frameworks

This binding library includes the following Facebook iOS SDK frameworks:

- **FBSDKCoreKit** - Core Facebook SDK functionality
- **FBSDKLoginKit** - Facebook Login functionality
- **FBAEMKit** - Aggregated Event Measurement kit
- **FBSDKCoreKit_Basics** - Basic utilities and shared components

## Installation

Install the package via NuGet Package Manager:

```
Install-Package iOS.Facebook.Bindings
```

Or via .NET CLI:

```
dotnet add package iOS.Facebook.Bindings
```

## Usages

Add the necessary using statements to your code:

```csharp
using FacebookiOSBindings;
```

```csharp
LoginManager loginManager = new LoginManager();

loginManager.LogIn(new[] { "public_profile" }, viewController,
    new LoginManagerLoginResultBlock((loginResult, e) =>
    {
        // Handle Login Logic
    })
);

loginManager.LogOut();
```

```csharp
FacebookiOSBindings.FBSDKApplicationDelegate.SharedInstance
```

```csharp
Profile.EnableUpdatesOnAccessTokenChange(true);
Profile.Notifications.ObserveDidChange((sender, e) => {
     // Handle Change Logic
});
```

## Requirements

- .NET 8.0 or later
- iOS deployment target: iOS 12.0 or later
- Xcode 14.0 or later

## License

This binding library is released under the MIT License. The Facebook iOS SDK itself is subject to Facebook's licensing terms.

## Support

For issues related to this binding library, please create an issue in the GitHub repository.
For issues related to the Facebook iOS SDK itself, please refer to the [Facebook Developers documentation](https://developers.facebook.com/).
