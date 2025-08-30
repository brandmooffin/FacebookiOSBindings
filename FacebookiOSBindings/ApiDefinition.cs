using ObjCRuntime;
using Foundation;
using UIKit;
using System;

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
    
    #region FBAEMReporter

    [BaseType(typeof(NSObject))]
    public interface FBAEMReporter
    {
        [Static]
        [Export("enable")]
        void Enable();
    }
    #endregion
    
    #region FBSDKLoginKit
    
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
    
    #endregion

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
        [Static]
        [NullAllowed]
        [Export("appID")]
        string AppId { get; set; }
        
        [Static]
        [NullAllowed]
        [Export("displayName")]
        string DisplayName { get; set; }
    }

    #region FBSDKShareKit

    [BaseType(typeof(UIButton), Name = "FBSDKSendButton")]
    public interface SendButton
    {
        [Export("shareContent")]
        ShareContent ShareContent { get; set; }
        
        [Export("configureButton")]
        void ConfigureButton();
        
        [Export("share")]
        void Share();
    }
    
    [BaseType(typeof(NSObject), Name = "FBSDKHashtag")]
    public interface Hashtag : INSSecureCoding
    {
        [Export("stringRepresentation")]
        string StringRepresentation { get; set; }
        
        [Export("initWithString:")]
        [DesignatedInitializer]
        IntPtr Constructor(string stringRepresentation);
        
        [Export("description")]
        string Description { get; }
        
        [Export("isValid")]
        bool IsValid { get; }
        
        [Export("hash")]
        nuint HashCode { get; }
    }
    
    [BaseType(typeof(NSObject), Name = "FBSDKShareContent")]
    public interface ShareContent : INSSecureCoding
    {
        [Export("contentURL", ArgumentSemantic.Strong)]
        NSUrl ContentUrl { get; set; }

        [Export("peopleIDs")]
        string[] PeopleIds { get; set; }
        
        [Export("placeID")]
        [NullAllowed]
        string PlaceId { get; set; }
        
        [Export("ref")]
        [NullAllowed]
        string Ref { get; set; }
        
        [Export("hashtag")]
        [NullAllowed]
        Hashtag Hashtag { get; set; }
        
        [Export("pageID")]
        [NullAllowed]
        string PageId { get; set; }
        
        [Export("shareUUID")]
        [NullAllowed]
        string ShareUuid { get; set; }
    }
    
    [BaseType(typeof(NSObject), Name = "FBSDKShareDialog")]
    public interface ShareDialog
    {
        [Static]
        [Export("showFromViewController:withContent:delegate:")]
        void Show(UIViewController viewController, ShareContent content, [NullAllowed] ShareDialogDelegate @delegate);

        [Export("mode")]
        ShareDialogMode Mode { get; set; }

        [Export("fromViewController", ArgumentSemantic.Strong)]
        UIViewController FromViewController { get; set; }
    }
    
    public delegate void ShareDialogDelegate([NullAllowed] ShareDialog dialog, [NullAllowed] NSError error);
    
    [BaseType(typeof(NSObject), Name = "FBSDKShareDialogMode")]
    public enum ShareDialogMode : long
    {
        Automatic,
        Native,
        Browser,
        Web,
        FeedBrowser,
        ShareSheet,
        Custom
    }
    
    #endregion
    
    #region FBSDKGamingServicesKit
    
    [BaseType(typeof(NSObject), Name = "AccessTokenProvider")]
    public interface AccessTokenProvider
    {
        [Static]
        [Export("current")]
        AccessToken CurrentAccessToken { get; }
    }
    
    [BaseType(typeof(NSObject), Name = "FBSDKGamingContext")]
    public interface GamingContext : INSSecureCoding
    {
        [Static]
        [Export("current")]
        GamingContext Current { get; }
        
    }
    
    #endregion
}