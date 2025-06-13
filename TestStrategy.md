# Facebook iOS Bindings Test Strategy

This document outlines the testing strategy for the Facebook iOS Bindings library.

## Two-Tier Testing Approach

### Tier 1: API Surface Tests (FacebookiOSBindings.Tests)
These tests verify that the API surface is correctly bound and accessible from .NET code. They do not require a functioning Facebook SDK or app credentials.

#### Test Categories:
- **ApiSurfaceTest**: Basic tests to verify classes can be instantiated
- **BindingStructureTest**: Reflection-based tests to verify method and property bindings
- **RequiresActualSDK**: Tests that require Facebook SDK initialization (skipped in CI)

### Tier 2: Integration Tests (FacebookiOSBindings.IntegrationTests)
These tests verify the actual functionality and interaction with the Facebook SDK. They require a configured Facebook app and proper initialization.

## Running Tests

### Local Development
Run all tests including integration tests:
```bash
dotnet test FacebookiOSBindings.Tests
dotnet test FacebookiOSBindings.IntegrationTests
```

Run only API surface tests (suitable for CI):
```bash
dotnet test FacebookiOSBindings.Tests --filter "Category!=RequiresActualSDK"
```

### CI Pipeline
The CI pipeline runs only the API surface tests that don't require Facebook credentials or SDK initialization.

## Setting Up Test Environment

To run tests that require Facebook SDK initialization:

1. Create a test Facebook app in the [Facebook Developer Portal](https://developers.facebook.com/)
2. Configure `FacebookTestInitializer.cs` with your test app credentials
3. Set up test iOS provisioning if running on real devices

## Test Coverage

The tests aim to verify:
1. All expected types from the Facebook SDK are properly bound
2. All properties and methods have correct signatures
3. The bindings work correctly with the actual Facebook SDK

## Adding New Tests

When adding new bindings:
1. Add the type to `ExpectedTypes` in `BindingCompletionTests.cs`
2. Add expected properties and methods to the respective dictionaries
3. Create specific test methods for important functionality
4. Use appropriate test categories to ensure CI compatibility
