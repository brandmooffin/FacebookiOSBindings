#!/usr/bin/env pwsh

Write-Host "Building and packaging FacebookiOSBindings..." -ForegroundColor Green

Write-Host "`nCleaning previous builds..." -ForegroundColor Yellow
dotnet clean

Write-Host "`nRestoring packages..." -ForegroundColor Yellow
dotnet restore

Write-Host "`nBuilding the project..." -ForegroundColor Yellow
dotnet build --configuration Release

Write-Host "`nCreating NuGet package..." -ForegroundColor Yellow
dotnet pack --configuration Release --output ./nupkg

Write-Host "`nPackage creation complete!" -ForegroundColor Green
Write-Host "Check the ./nupkg folder for your .nupkg file." -ForegroundColor Cyan
