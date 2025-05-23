@echo off
echo Building and packaging FacebookiOSBindings...

echo.
echo Cleaning previous builds...
dotnet clean

echo.
echo Restoring packages...
dotnet restore

echo.
echo Building the project...
dotnet build --configuration Release

echo.
echo Creating NuGet package...
dotnet pack --configuration Release --output ./nupkg

echo.
echo Package creation complete!
echo Check the ./nupkg folder for your .nupkg file.

pause
