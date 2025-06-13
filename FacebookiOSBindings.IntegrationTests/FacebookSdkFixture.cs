using FacebookiOSBindings.Tests.Helpers;

namespace FacebookiOSBindings.IntegrationTests;

/// <summary>
/// Test fixture that initializes the Facebook SDK for integration tests
/// </summary>
public class FacebookSdkFixture : IDisposable
{
    public FacebookSdkFixture()
    {
        // Initialize the Facebook SDK for testing
        // Note: This is commented out because it requires actual configuration
        // FacebookTestInitializer.Initialize();
    }
    
    public void Dispose()
    {
        // Clean up if needed
    }
}

[CollectionDefinition("Facebook SDK Collection")]
public class FacebookSdkCollection : ICollectionFixture<FacebookSdkFixture>
{
    // This class has no code, and is never created. Its purpose is to be the place
    // to apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
}
