using Foundation;
using UIKit;

namespace FacebookiOSBindings.Tests.Helpers;

/// <summary>
/// Helper class for Facebook SDK initialization in test environments
/// </summary>
public static class FacebookTestInitializer
{
    private const string TestAppId = "YOUR_TEST_APP_ID";
    private const string TestAppName = "Facebook Test App";
    
    /// <summary>
    /// Initializes the Facebook SDK for testing purposes.
    /// Should be called in test setup code.
    /// </summary>
    public static void Initialize()
    {
        // Set up required values in the Info.plist dictionary in memory
        // This mimics having the values in a real Info.plist file
        var bundle = NSBundle.MainBundle;
        if (bundle.InfoDictionary == null)
        {
            // In test environments, we might need to create this dictionary
            var dict = new NSMutableDictionary();
            dict.SetValueForKey(new NSString(TestAppId), new NSString("FacebookAppID"));
            dict.SetValueForKey(new NSString(TestAppName), new NSString("FacebookDisplayName"));
            
            // We can't actually modify the main bundle's dictionary, but in a real app
            // you would include these values in your Info.plist
        }
        
        // You could also configure Settings directly if the SDK allows it
        Settings.DisplayName = TestAppName;
        
        // Initialize the SDK - this would be done differently in a real app
        // For testing purposes, this is a simplified version
        var application = UIApplication.SharedApplication;
        var didFinishLaunching = FBSDKApplicationDelegate.SharedInstance.FinishedLaunching(application, null);
    }
}
