# API Reference

## Overview

The Library Management System API is documented using **OpenAPI 3.0** (Swagger).

## Interactive Documentation

When running in Development mode, Swagger UI is available at:

```
https://localhost:5001/swagger
```

## OpenAPI Specification

The machine-readable OpenAPI specification can be downloaded from:

```
https://localhost:5001/swagger/v1/swagger.json
```

## Endpoints Summary

### Books (`/api/books`)

| Method | Path | Summary |
|---|---|---|
| `GET` | `/api/books` | Get all books |
| `GET` | `/api/books/{id}` | Get book by ID |
| `GET` | `/api/books/available` | Get available books |
| `POST` | `/api/books` | Create a new book |
| `PUT` | `/api/books/{id}` | Update a book |
| `DELETE` | `/api/books/{id}` | Delete a book |

### Book Categories (`/api/bookcategories`)

| Method | Path | Summary |
|---|---|---|
| `GET` | `/api/bookcategories` | Get all categories |
| `GET` | `/api/bookcategories/{id}` | Get category by ID |

### Customers (`/api/customers`)

| Method | Path | Summary |
|---|---|---|
| `GET` | `/api/customers` | Get all customers |
| `GET` | `/api/customers/{id}` | Get customer by ID |
| `GET` | `/api/customers/active` | Get active customers |
| `POST` | `/api/customers` | Create a new customer |
| `PUT` | `/api/customers/{id}` | Update a customer |
| `DELETE` | `/api/customers/{id}` | Delete a customer |

### Staff (`/api/staff`)

| Method | Path | Summary |
|---|---|---|
| `GET` | `/api/staff` | Get all staff |
| `GET` | `/api/staff/{id}` | Get staff by ID |
| `GET` | `/api/staff/active` | Get active staff |
| `POST` | `/api/staff` | Create staff member |
| `PUT` | `/api/staff/{id}` | Update staff member |
| `DELETE` | `/api/staff/{id}` | Delete staff member |

## Data Models

### BookDto

```json
{
  "id": "guid",
  "title": "string",
  "author": "string",
  "isbn": "string",
  "publishedYear": 0,
  "isAvailable": true,
  "bookCategoryId": "guid | null"
}
```

### BookCategoryDto

```json
{
  "id": "guid",
  "name": "string",
  "description": "string"
}
```

### CustomerDto

```json
{
  "id": "guid",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string",
  "address": "string",
  "membershipNumber": "string",
  "registeredDate": "datetime",
  "isActive": true
}
```

### StaffDto

```json
{
  "id": "guid",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string",
  "position": "string",
  "hireDate": "datetime",
  "isActive": true
}
```

## Generating Updated Docs

To regenerate the OpenAPI spec from code:

1. Run the application
2. Download `swagger/v1/swagger.json`
3. Copy to `integrations/schemas/openapi.yaml` (convert if needed)
