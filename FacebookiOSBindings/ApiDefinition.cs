using ObjCRuntime;
using Foundation;
using UIKit;

namespace FacebookiOSBindings
{
    [BaseType(typeof(NSObject))]
    public interface FBSDKApplicationDelegate
    {
        [Static]
        [Export("sharedInstance")]
        FBSDKApplicationDelegate SharedInstance { get; }

        [Export("application:didFinishLaunchingWithOptions:")]
        bool FinishedLaunching([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);
        
        [Export("application:openURL:sourceApplication:annotation:")]
        bool OpenUrl(UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
        
        [Export("application:continueUserActivity:")]
        bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity);

        [Export("application:openURL:options:")]
        bool OpenUrl(UIApplication application, NSUrl url, [NullAllowed] NSDictionary options);
    }

    [BaseType(typeof(NSObject))]
    public interface FBAEMReporter
    {
        [Static]
        [Export("enable")]
        void Enable();
    }

    [BaseType(typeof(NSObject), Name = "FBSDKLoginManager")]
    public interface LoginManager
    {
        [Export("logInWithPermissions:fromViewController:handler:")]
        void LogIn(string[] permissions, [NullAllowed] UIViewController viewController, [NullAllowed] LoginManagerLoginResultBlock handler);

		[Export("logOut")]
		void LogOut();
    }

    public delegate void LoginManagerLoginResultBlock([NullAllowed] LoginManagerLoginResult result, [NullAllowed] NSError error);

    [BaseType(typeof(NSObject), Name = "FBSDKLoginManagerLoginResult")]
    public interface LoginManagerLoginResult
    {
        [Export("isCancelled")]
        bool IsCancelled { get; }

        [Export("token")]
        AccessToken Token { get; }
    }

    [BaseType(typeof(NSObject), Name = "FBSDKAccessToken")]
    public interface AccessToken
    {
        [Static]
        [Export("currentAccessToken")]
        AccessToken CurrentAccessToken { get; }

        [Export("userID")]
        string UserID { get; }
    }

    interface ProfileDidChangeEventArgs
    {
        [Export("FBSDKProfileChangeOldKey")]
        Profile OldProfile { get; }
        
        [Export("FBSDKProfileChangeNewKey")]
        Profile NewProfile { get; }
    }
    
    [BaseType(typeof(NSObject), Name = "FBSDKProfile")]
    public interface Profile : INSCopying, INSSecureCoding
    {
        [Notification (typeof(ProfileDidChangeEventArgs))]
        [Field ("FBSDKProfileDidChangeNotification", "__Internal")]
        NSString DidChangeNotification { get; }
        
        [Field("FBSDKProfileChangeOldKey", "__Internal")]
        NSString OldProfileKey { get; }
        
        [Field("FBSDKProfileChangeNewKey", "__Internal")]
        NSString NewProfileKey { get; }
        
        [Static]
        [Export("enableUpdatesOnAccessTokenChange:")]
        void EnableUpdatesOnAccessTokenChange(bool enable);
        
        [Export("requestProfileForCurrentAccessToken")]
        void RequestProfileForCurrentAccessToken();
        
        [Static]
        [Export("currentProfile", ArgumentSemantic.Strong)]
        Profile CurrentProfile { get; set; }
        
        [Export("userID")]
        string UserId { get; }
        
        [NullAllowed]
        [Export("firstName")]
        string FirstName { get; }
        
        [NullAllowed]
        [Export("lastName")]
        string LastName { get; }
    }

    [BaseType(typeof(NSObject), Name = "FBSDKSettings")]
    public interface Settings
    {
        // [Static]
        // [NullAllowed]
        // [Export("appID")]
        // string AppId { get; set; }
        
        [Static]
        [NullAllowed]
        [Export("displayName")]
        string DisplayName { get; set; }
    }
}