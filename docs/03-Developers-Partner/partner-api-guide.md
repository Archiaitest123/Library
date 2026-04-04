# Partner API Guide

## Introduction

The Library Management System exposes a RESTful API that partner applications can integrate with. This guide covers authentication, available endpoints, and integration patterns.

## Base URL

| Environment | URL |
|---|---|
| Development | `https://localhost:5001/api` |
| Test | `https://library-api-test.example.com/api` |
| Production | `https://library-api.example.com/api` |

## API Format

- **Protocol:** HTTPS
- **Content-Type:** `application/json`
- **ID Format:** GUID (`xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`)

## Available Resources

### Books

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/books` | List all books |
| GET | `/api/books/{id}` | Get a specific book |
| GET | `/api/books/available` | List available books |
| POST | `/api/books` | Create a new book |
| PUT | `/api/books/{id}` | Update a book |
| DELETE | `/api/books/{id}` | Delete a book |

### Book Categories

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/bookcategories` | List all categories |
| GET | `/api/bookcategories/{id}` | Get a specific category |

### Customers

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/customers` | List all customers |
| GET | `/api/customers/{id}` | Get a specific customer |
| GET | `/api/customers/active` | List active customers |
| POST | `/api/customers` | Create a new customer |
| PUT | `/api/customers/{id}` | Update a customer |
| DELETE | `/api/customers/{id}` | Delete a customer |

### Staff

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/staff` | List all staff |
| GET | `/api/staff/{id}` | Get a specific staff member |
| GET | `/api/staff/active` | List active staff |
| POST | `/api/staff` | Create a new staff member |
| PUT | `/api/staff/{id}` | Update a staff member |
| DELETE | `/api/staff/{id}` | Delete a staff member |

## Request / Response Examples

### Create a Book

**Request:**
```http
POST /api/books
Content-Type: application/json

{
  "title": "Clean Architecture",
  "author": "Robert C. Martin",
  "isbn": "978-0134494166",
  "publishedYear": 2017,
  "isAvailable": true,
  "bookCategoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

**Response (201 Created):**
```json
{
  "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "title": "Clean Architecture",
  "author": "Robert C. Martin",
  "isbn": "978-0134494166",
  "publishedYear": 2017,
  "isAvailable": true,
  "bookCategoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### Error Responses

| Status Code | Meaning |
|---|---|
| 200 | Success |
| 201 | Resource created |
| 204 | Success (no content — updates, deletes) |
| 400 | Bad request (validation errors) |
| 404 | Resource not found |
| 500 | Internal server error |

## Rate Limiting

Currently no rate limiting is enforced. Partners should implement reasonable request throttling on their side.

## Swagger / OpenAPI

Interactive API documentation is available at:
- **Swagger UI:** `{base-url}/swagger`
- **OpenAPI spec:** `{base-url}/swagger/v1/swagger.json`
