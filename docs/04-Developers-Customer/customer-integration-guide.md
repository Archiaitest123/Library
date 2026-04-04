# Customer Integration Guide

## Overview

This guide helps customer-side developers integrate their applications with the Library Management System API. It covers how to manage customer records, query books, and handle common integration scenarios.

## Getting Started

### 1. API Access

| Environment | Base URL |
|---|---|
| Test | `https://library-api-test.example.com/api` |
| Production | `https://library-api.example.com/api` |

### 2. Prerequisites

- HTTP client library (e.g., `HttpClient` in .NET, `axios` in JavaScript)
- JSON serialization support
- Network access to the API endpoint

## Customer Management

### Register a New Customer

```http
POST /api/customers
Content-Type: application/json

{
  "firstName": "Mehmet",
  "lastName": "Demir",
  "email": "mehmet.demir@example.com",
  "phone": "+905559876543",
  "address": "Ankara, Türkiye",
  "membershipNumber": "MBR-2024-100"
}
```

> **Note:** `membershipNumber` and `email` must be unique across the system.

### Retrieve Customer by ID

```http
GET /api/customers/{id}
```

### List Active Customers

```http
GET /api/customers/active
```

### Update Customer Details

```http
PUT /api/customers/{id}
Content-Type: application/json

{
  "firstName": "Mehmet",
  "lastName": "Demir",
  "email": "mehmet.new@example.com",
  "phone": "+905559876543",
  "address": "Ankara, Türkiye",
  "membershipNumber": "MBR-2024-100",
  "isActive": true
}
```

## Book Search

### List All Books

```http
GET /api/books
```

### List Available Books Only

```http
GET /api/books/available
```

### Browse by Category

```http
GET /api/bookcategories
GET /api/bookcategories/{categoryId}
```

## .NET Integration Example

```csharp
using System.Net.Http.Json;

var client = new HttpClient
{
    BaseAddress = new Uri("https://library-api.example.com/api/")
};

// Get available books
var books = await client.GetFromJsonAsync<List<BookDto>>("books/available");

// Create a customer
var newCustomer = new
{
    FirstName = "Ayşe",
    LastName = "Kara",
    Email = "ayse.kara@example.com",
    Phone = "+905551112233",
    Address = "İzmir, Türkiye",
    MembershipNumber = "MBR-2024-200"
};

var response = await client.PostAsJsonAsync("customers", newCustomer);
response.EnsureSuccessStatusCode();
```

## Error Handling

| Status | Cause | Action |
|---|---|---|
| 400 | Invalid request body | Check required fields and data formats |
| 404 | Resource not found | Verify the ID/endpoint |
| 409 | Conflict (duplicate email/ISBN) | Use a unique value |
| 500 | Server error | Retry with exponential backoff, contact support |
