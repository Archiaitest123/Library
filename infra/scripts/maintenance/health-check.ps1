<#
.SYNOPSIS
    Basic health check for the Library API.
.DESCRIPTION
    Pings all major endpoints to verify the API is responsive.
.PARAMETER BaseUrl
    The base URL of the Library API.
#>

param(
    [string]$BaseUrl = "https://localhost:5001"
)

$ErrorActionPreference = "Continue"

Write-Host "=== Library API Health Check ===" -ForegroundColor Cyan
Write-Host "Target: $BaseUrl`n"

$endpoints = @(
    "/api/books",
    "/api/bookcategories",
    "/api/customers",
    "/api/staff"
)

$allOk = $true

foreach ($endpoint in $endpoints) {
    $url = "$BaseUrl$endpoint"
    try {
        $sw = [System.Diagnostics.Stopwatch]::StartNew()
        $response = Invoke-WebRequest -Uri $url -Method Get -UseBasicParsing -TimeoutSec 10
        $sw.Stop()
        $status = $response.StatusCode
        $ms = $sw.ElapsedMilliseconds
        Write-Host "  [OK]   $endpoint - $status ($($ms)ms)" -ForegroundColor Green
    }
    catch {
        $allOk = $false
        Write-Host "  [FAIL] $endpoint - $($_.Exception.Message)" -ForegroundColor Red
    }
}

Write-Host ""
if ($allOk) {
    Write-Host "All endpoints are healthy." -ForegroundColor Green
} else {
    Write-Host "Some endpoints are failing!" -ForegroundColor Red
    exit 1
}
