# ADR-001: Use Clean Architecture

## Status
Accepted

## Context
The Library Management System needs a maintainable, testable architecture that separates concerns and allows independent evolution of layers.

## Decision
We adopt Clean Architecture with the following layers:
- **Domain** – Core entities and repository interfaces (no external dependencies)
- **Application** – Business logic, services, DTOs
- **Infrastructure** – Data access (EF Core), email, external integrations
- **API** – ASP.NET Core Web API presentation layer

## Consequences
- Clear separation of concerns
- Domain layer remains pure and testable
- Infrastructure can be swapped without affecting business logic
- Additional boilerplate for mapping between layers

---

# ADR-002: Use Entity Framework Core with SQL Server

## Status
Accepted

## Context
The project needs a reliable, well-supported ORM with SQL Server as the primary database.

## Decision
Use Entity Framework Core 8 with the SQL Server provider. Configure entity relationships and constraints via Fluent API in `LibraryDbContext.OnModelCreating`.

## Consequences
- Strong typing and LINQ support for queries
- Migration support for schema evolution
- Tight coupling to EF Core (mitigated by repository pattern)

---

# ADR-003: Repository Pattern

## Status
Accepted

## Context
We need to abstract data access to allow unit testing of services without a real database.

## Decision
Define generic `IRepository<T>` and entity-specific interfaces (e.g., `IBookRepository`) in the Domain layer. Implementations reside in Infrastructure.

## Consequences
- Services depend on abstractions, not concrete data access
- Easy to create in-memory implementations for testing (e.g., `InMemoryBookRepository`)
- Additional interfaces to maintain

---

# ADR-004: DTO-Based API Contracts

## Status
Accepted

## Context
Domain entities should not be directly exposed to API consumers to avoid tight coupling and over-posting vulnerabilities.

## Decision
Use separate DTOs for Create, Update, and Read operations. Manual mapping classes in `Library.Application.Mappings` handle entity ↔ DTO conversions.

## Consequences
- API contracts are decoupled from domain model
- Explicit control over what is exposed
- Manual mapping code required (could be replaced by AutoMapper in the future)
