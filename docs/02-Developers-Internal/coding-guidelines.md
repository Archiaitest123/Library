# Coding Guidelines

## General

- **Target Framework:** .NET 8
- **Language Version:** C# 12 (implicit)
- **Nullable Reference Types:** Enabled in all projects
- **Implicit Usings:** Enabled

## Naming Conventions

| Element | Convention | Example |
|---|---|---|
| Namespace | PascalCase, matches folder | `Library.Domain.Entities` |
| Class | PascalCase | `BookService` |
| Interface | `I` + PascalCase | `IBookRepository` |
| Method | PascalCase, async suffix | `GetAllAsync()` |
| Property | PascalCase | `FirstName` |
| Private field | `_camelCase` | `_bookService` |
| Parameter | camelCase | `createBookDto` |
| DTO | Suffix with `Dto` | `BookDto`, `CreateBookDto` |

## File Organization

- One class/interface per file
- File-scoped namespaces (`namespace X.Y.Z;`)
- Organize by feature within layer folders (DTOs, Services, Interfaces, etc.)

## Domain Layer Rules

- **No external NuGet dependencies** — the Domain project has zero package references
- Entities are simple POCOs with properties
- Repository interfaces define data access contracts
- No business logic in entities (services handle orchestration)

## Application Layer Rules

- Services implement business logic and coordinate repositories
- DTOs are used for input/output — never expose domain entities directly
- Mapping classes handle entity ↔ DTO conversion
- `DependencyInjection.cs` registers all application services

## Infrastructure Layer Rules

- Implements repository interfaces from Domain
- Contains EF Core `DbContext` with Fluent API configuration
- Entity configurations are in `OnModelCreating` (inline, not separate files)
- `DependencyInjection.cs` registers DbContext, repositories, and external services

## API Layer Rules

- Controllers inherit from `ControllerBase` with `[ApiController]` attribute
- Route convention: `api/[controller]`
- Return `ActionResult<T>` for type-safe responses
- Use `CreatedAtAction` for POST responses
- Handle `KeyNotFoundException` for update operations returning 404

## Error Handling

- Services throw `KeyNotFoundException` when entity is not found during updates
- Controllers catch exceptions and return appropriate HTTP status codes
- 404 for not found, 204 for successful updates/deletes, 201 for creates

## Testing

- Use in-memory repositories for unit testing (e.g., `InMemoryBookRepository`)
- Test services independently from infrastructure
