namespace FacebookiOSBindings.Tests;

/// <summary>
/// Categories for organizing test cases and enabling filtering
/// </summary>
public static class TestCategories
{
    /// <summary>
    /// Category for tests that require the actual Facebook SDK initialization
    /// These tests may be skipped in CI environments
    /// </summary>
    public const string RequiresActualSDK = "RequiresActualSDK";
    
    /// <summary>
    /// Category for tests that verify the API surface only
    /// These tests do not require actual SDK initialization and can run in CI
    /// </summary>
    public const string ApiSurfaceTest = "ApiSurfaceTest";
    
    /// <summary>
    /// Category for tests that verify the binding structure using reflection
    /// These tests do not require actual SDK initialization and can run in CI
    /// </summary>
    public const string BindingStructureTest = "BindingStructureTest";
}
