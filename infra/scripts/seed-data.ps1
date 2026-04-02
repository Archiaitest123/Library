<#
.SYNOPSIS
    Seeds the Library database with sample data.
.DESCRIPTION
    Inserts sample book categories, books, customers, and staff records via the API.
.PARAMETER BaseUrl
    The base URL of the Library API. Defaults to https://localhost:5001.
#>

param(
    [string]$BaseUrl = "https://localhost:5001"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Library DB Seed ===" -ForegroundColor Cyan
Write-Host "API Base URL: $BaseUrl"

# Sample Book Categories
$categories = @(
    @{ name = "Fiction"; description = "Fictional literature and novels" },
    @{ name = "Science"; description = "Scientific publications and textbooks" },
    @{ name = "History"; description = "Historical books and biographies" },
    @{ name = "Technology"; description = "Computer science and software engineering" },
    @{ name = "Children"; description = "Books for children and young adults" }
)

Write-Host "`nSeeding Book Categories..." -ForegroundColor Yellow
foreach ($cat in $categories) {
    try {
        $body = $cat | ConvertTo-Json
        $response = Invoke-RestMethod -Uri "$BaseUrl/api/bookcategories" -Method Post -Body $body -ContentType "application/json"
        Write-Host "  Created: $($response.name)" -ForegroundColor Green
    }
    catch {
        Write-Host "  Skipped: $($cat.name) - $($_.Exception.Message)" -ForegroundColor DarkYellow
    }
}

# Sample Staff
$staffList = @(
    @{ firstName = "Ahmet"; lastName = "Yilmaz"; email = "ahmet.yilmaz@library.local"; phone = "+905551001001"; position = "Head Librarian" },
    @{ firstName = "Fatma"; lastName = "Demir"; email = "fatma.demir@library.local"; phone = "+905551001002"; position = "Librarian" },
    @{ firstName = "Mehmet"; lastName = "Kaya"; email = "mehmet.kaya@library.local"; phone = "+905551001003"; position = "Assistant" }
)

Write-Host "`nSeeding Staff..." -ForegroundColor Yellow
foreach ($s in $staffList) {
    try {
        $body = $s | ConvertTo-Json
        $response = Invoke-RestMethod -Uri "$BaseUrl/api/staff" -Method Post -Body $body -ContentType "application/json"
        Write-Host "  Created: $($response.firstName) $($response.lastName)" -ForegroundColor Green
    }
    catch {
        Write-Host "  Skipped: $($s.firstName) $($s.lastName) - $($_.Exception.Message)" -ForegroundColor DarkYellow
    }
}

# Sample Customers
$customers = @(
    @{ firstName = "Ali"; lastName = "Ozturk"; email = "ali.ozturk@example.com"; phone = "+905552001001"; address = "Istanbul, Turkey"; membershipNumber = "MBR-2024-001" },
    @{ firstName = "Ayse"; lastName = "Celik"; email = "ayse.celik@example.com"; phone = "+905552001002"; address = "Ankara, Turkey"; membershipNumber = "MBR-2024-002" },
    @{ firstName = "Zeynep"; lastName = "Arslan"; email = "zeynep.arslan@example.com"; phone = "+905552001003"; address = "Izmir, Turkey"; membershipNumber = "MBR-2024-003" }
)

Write-Host "`nSeeding Customers..." -ForegroundColor Yellow
foreach ($c in $customers) {
    try {
        $body = $c | ConvertTo-Json
        $response = Invoke-RestMethod -Uri "$BaseUrl/api/customers" -Method Post -Body $body -ContentType "application/json"
        Write-Host "  Created: $($response.firstName) $($response.lastName)" -ForegroundColor Green
    }
    catch {
        Write-Host "  Skipped: $($c.firstName) $($c.lastName) - $($_.Exception.Message)" -ForegroundColor DarkYellow
    }
}

Write-Host "`nSeed completed!" -ForegroundColor Cyan
