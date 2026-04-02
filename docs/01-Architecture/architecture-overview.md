# Architecture Overview

## Summary

Library Management System is a RESTful web API built with ASP.NET Core 8 using **Clean Architecture** principles. The system manages books, book categories, customers, and staff for a library operation.

## Context Diagram

```
┌─────────────┐       HTTPS/JSON        ┌──────────────────────┐
│  Client App  │ ◄────────────────────► │   Library Web API     │
│  (Browser /  │                        │   (ASP.NET Core 8)    │
│   Mobile)    │                        └──────────┬───────────┘
└─────────────┘                                    │
                                                   │ EF Core
                                                   ▼
                                          ┌──────────────────┐
                                          │   SQL Server DB   │
                                          │   (LibraryDb)     │
                                          └──────────────────┘
                                                   │
                                          ┌──────────────────┐
                                          │   SMTP Server     │
                                          │   (Email Service) │
                                          └──────────────────┘
```

## Layered Architecture

```
┌─────────────────────────────────────────────────────┐
│                   Library (API)                      │
│          Controllers, Middleware, Swagger             │
├─────────────────────────────────────────────────────┤
│              Library.Application                     │
│       Services, DTOs, Mappings, Validators           │
├─────────────────────────────────────────────────────┤
│               Library.Domain                         │
│     Entities, Repository Interfaces, Enums           │
├─────────────────────────────────────────────────────┤
│            Library.Infrastructure                    │
│   EF Core DbContext, Repositories, Email Service     │
└─────────────────────────────────────────────────────┘
```

## Key Design Decisions

- **Dependency direction:** All dependencies point inward. Domain has no external dependencies.
- **Repository pattern:** Domain defines interfaces, Infrastructure provides implementations.
- **Service layer:** Application layer coordinates business logic through service classes.
- **DTO pattern:** Application layer uses DTOs to decouple API contracts from domain entities.

## Technology Stack

| Component | Technology |
|---|---|
| Runtime | .NET 8 |
| Web Framework | ASP.NET Core 8 |
| ORM | Entity Framework Core 8 (SQL Server) |
| API Docs | Swashbuckle / Swagger |
| Email | SMTP via SmtpEmailService |

## Data Model

### Entities

- **Book** – Id, Title, Author, ISBN (unique), PublishedYear, IsAvailable, BookCategoryId
- **BookCategory** – Id, Name (unique), Description → has many Books
- **Customer** – Id, FirstName, LastName, Email (unique), Phone, Address, MembershipNumber (unique), RegisteredDate, IsActive
- **Staff** – Id, FirstName, LastName, Email (unique), Phone, Position, HireDate, IsActive

### Relationships

- `BookCategory` 1 ──── N `Book` (optional FK, on delete set null)
