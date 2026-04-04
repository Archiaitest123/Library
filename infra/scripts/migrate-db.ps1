<#
.SYNOPSIS
    Applies EF Core migrations to the Library database.
.DESCRIPTION
    Runs 'dotnet ef database update' against the Library.Infrastructure project.
.PARAMETER Environment
    The target environment (Development, Test, Production). Defaults to Development.
#>

param(
    [string]$Environment = "Development"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Library DB Migration ===" -ForegroundColor Cyan
Write-Host "Environment: $Environment"

$env:ASPNETCORE_ENVIRONMENT = $Environment

$solutionRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)

Push-Location $solutionRoot
try {
    Write-Host "Restoring packages..." -ForegroundColor Yellow
    dotnet restore

    Write-Host "Applying migrations..." -ForegroundColor Yellow
    dotnet ef database update `
        --project Library.Infrastructure `
        --startup-project Library `
        --verbose

    Write-Host "Migration completed successfully!" -ForegroundColor Green
}
catch {
    Write-Host "Migration failed: $_" -ForegroundColor Red
    exit 1
}
finally {
    Pop-Location
}
