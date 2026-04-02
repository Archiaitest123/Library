# Authentication & Scopes

## Current State

The Library Management System currently does **not** enforce authentication or authorization. All API endpoints are publicly accessible.

## Planned Authentication

The following authentication strategy is planned for future implementation:

### JWT Bearer Authentication

```
Client → POST /api/auth/login → JWT Token
Client → GET /api/books (Authorization: Bearer <token>) → 200 OK
```

### Token Format

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

### Planned Scopes

| Scope | Description | Endpoints |
|---|---|---|
| `books.read` | Read book data | GET `/api/books/*` |
| `books.write` | Create, update, delete books | POST, PUT, DELETE `/api/books/*` |
| `customers.read` | Read customer data | GET `/api/customers/*` |
| `customers.write` | Manage customers | POST, PUT, DELETE `/api/customers/*` |
| `staff.read` | Read staff data | GET `/api/staff/*` |
| `staff.write` | Manage staff | POST, PUT, DELETE `/api/staff/*` |
| `categories.read` | Read categories | GET `/api/bookcategories/*` |

### Partner Roles

| Role | Scopes |
|---|---|
| Reader | `books.read`, `categories.read` |
| Librarian | All `*.read`, `books.write`, `customers.write` |
| Admin | All scopes |

## Integration Notes

- Until authentication is implemented, no `Authorization` header is required
- Partners should design their integration to support Bearer token auth for future compatibility
- API keys may be introduced as an alternative for server-to-server integrations
