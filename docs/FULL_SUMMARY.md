## 1. Overview
`BookCategoryDto` is a simple Data Transfer Object (DTO) representing a book category with an identifier, name, and description. It is part of the application layer and is intended for transporting category data between layers (e.g., application to API/UI) without domain behavior.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the book category. |
| Name | `string Name { get; set; }` | Human-readable name of the category; defaults to empty string. |
| Description | `string Description { get; set; }` | Optional descriptive text; defaults to empty string. |

## 5. Key Behaviors & Business Rules
- No validation or business rules are enforced in this DTO.
- String properties are initialized to empty strings to avoid nulls.

## 6. Connections
- Located in the application layer (`Library.Application.DTOs`); designed to be consumed by higher layers such as API controllers or UI mappers and supplied by application/services. Specific upstream callers or downstream dependencies are not indicated in this file.## 1. Overview
`BookDto` is a data transfer object representing book information used in the application layer. It encapsulates basic metadata about a book and optional category details for transport between layers (e.g., from domain/data to API).

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier of the book. |
| Title | `string Title { get; set; }` | Book title; defaults to empty string. |
| Author | `string Author { get; set; }` | Book author; defaults to empty string. |
| ISBN | `string ISBN { get; set; }` | International Standard Book Number; defaults to empty string. |
| PublishedYear | `int PublishedYear { get; set; }` | Year the book was published. |
| IsAvailable | `bool IsAvailable { get; set; }` | Availability flag indicating if the book can be borrowed/used. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Optional identifier for the book’s category. |
| BookCategoryName | `string? BookCategoryName { get; set; }` | Optional display name of the book’s category. |

## 5. Key Behaviors & Business Rules
- Simple DTO with auto-properties; no validation, transformation, or logic.
- String properties (`Title`, `Author`, `ISBN`) default to empty strings to avoid nulls.
- Category-related properties are optional, allowing uncategorized books (`Guid?` and `string?`).

## 6. Connections
- Intended for use within the application layer (`Library.Application.DTOs`) as a contract between layers (e.g., mapping from domain entities to API responses or commands). No direct interactions or external service calls are defined in this file.## 1. Overview
`CreateBookCategoryDto` is a simple Data Transfer Object (DTO) used to carry input data for creating a book category. It lives in the application layer’s DTOs, facilitating data exchange between external/API layers and the application’s command/handler logic without embedding domain behavior.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Name | `string Name { get; set; }` | The category name; defaults to empty string. |
| Description | `string Description { get; set; }` | A human-readable description of the category; defaults to empty string. |

## 6. Connections
- Upstream: Typically populated by API controllers or clients submitting create-category requests.
- Downstream: Likely consumed by application handlers/services that execute the create category operation (not shown in this file).# Overview
`CreateBookDto` is a simple Data Transfer Object in the application layer used to carry data required to create a book. It encapsulates primitive fields for a book’s basic attributes and is intended for use in the `Library.Application.DTOs` namespace.

# Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| Title | `string Title { get; set; }` | Book title; initialized to `string.Empty` to avoid nulls. |
| Author | `string Author { get; set; }` | Book author; initialized to `string.Empty`. |
| ISBN | `string ISBN { get; set; }` | Book ISBN; initialized to `string.Empty`. |
| PublishedYear | `int PublishedYear { get; set; }` | Year the book was published; default `0` if not set. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Optional category identifier; nullable `Guid`. |

# Key Behaviors & Business Rules
- No methods or validation logic are present; this type solely holds data.
- String properties (`Title`, `Author`, `ISBN`) default to `string.Empty`, preventing null reference concerns for unset strings.
- `BookCategoryId` is nullable, allowing omission of a category during creation.
- No exception handling, caching, or side effects are implemented.

# Connections
- Located in `Library.Application.DTOs`, indicating it is part of the application layer’s data contracts.
- No explicit upstream callers or downstream dependencies are shown in this file.# Overview
A simple Data Transfer Object (DTO) used to carry customer creation data across application boundaries. It resides in the application layer and encapsulates basic customer fields without behavior, validation, or persistence logic.

# Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| FirstName | `string FirstName { get; set; }` | Customer’s given name; defaults to `string.Empty`. |
| LastName | `string LastName { get; set; }` | Customer’s family name; defaults to `string.Empty`. |
| Email | `string Email { get; set; }` | Customer’s email address; defaults to `string.Empty`. |
| Phone | `string Phone { get; set; }` | Customer’s phone number; defaults to `string.Empty`. |
| Address | `string Address { get; set; }` | Customer’s address; defaults to `string.Empty`. |

# Key Behaviors & Business Rules
- All properties are auto-properties with public getters and setters.
- Each property is initialized to `string.Empty`, preventing null strings by default.
- No validation, formatting, or transformation logic is present.
- No exception handling, caching, or side effects are implemented.

# Connections
- Defined in the application DTOs namespace, indicating use as a data carrier in application workflows.
- No direct interactions or references to other classes/services are present in this file.## 1. Overview
`CreateStaffDto` is a data transfer object used to carry input data required to create a staff member. It resides in the application layer DTOs, encapsulating simple, serializable fields without behavior for use across boundaries (e.g., API to application services).

## 2. Type Info
- Type: `class`
- Inherits: `object`
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| FirstName | `string FirstName { get; set; }` | Given name of the staff member. |
| LastName | `string LastName { get; set; }` | Surname of the staff member. |
| Email | `string Email { get; set; }` | Email address of the staff member. |
| Phone | `string Phone { get; set; }` | Phone number of the staff member. |
| Position | `string Position { get; set; }` | Job title or role of the staff member. |
| HireDate | `DateTime HireDate { get; set; }` | Date the staff member was hired. |

## 5. Key Behaviors & Business Rules
- No logic, validation, or side effects; acts as a simple data container.
- String properties are initialized to `string.Empty`; `HireDate` defaults to `default(DateTime)` unless set.

## 6. Connections
- Intended for use by application services or API endpoints that handle staff creation workflows. No direct interactions or external references appear in this file.## 1. Overview
`CustomerDto` is a simple Data Transfer Object representing customer information within the application layer. It exists to carry customer-related data between layers (e.g., application services and presentation) without exposing domain entities. It fits in the Application layer under DTOs.

## 2. Type Info
- Type: `class`
- Inherits: `object`
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the customer. |
| FirstName | `string FirstName { get; set; }` | Customer’s first name; defaults to empty string. |
| LastName | `string LastName { get; set; }` | Customer’s last name; defaults to empty string. |
| Email | `string Email { get; set; }` | Customer’s email address; defaults to empty string. |
| Phone | `string Phone { get; set; }` | Customer’s phone number; defaults to empty string. |
| Address | `string Address { get; set; }` | Customer’s address; defaults to empty string. |
| MembershipNumber | `string MembershipNumber { get; set; }` | Membership identifier; defaults to empty string. |
| RegisteredDate | `DateTime RegisteredDate { get; set; }` | Date the customer registered. |
| IsActive | `bool IsActive { get; set; }` | Indicates whether the customer is active. |

## 5. Key Behaviors & Business Rules
(Section intentionally omitted; this is a simple DTO without behavior.)

## 6. Connections
- No direct interactions are defined in this file. It is intended to be used wherever customer data needs to be transported within the application layer.## 1. Overview
`StaffDto` is a Data Transfer Object used to carry staff-related data across application boundaries. It encapsulates basic identifying and contact information along with employment metadata. It resides in the application layer (DTOs) to decouple domain/entities from API or persistence representations.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the staff member. |
| FirstName | `string FirstName { get; set; }` | Staff member’s first name; defaults to empty string. |
| LastName | `string LastName { get; set; }` | Staff member’s last name; defaults to empty string. |
| Email | `string Email { get; set; }` | Staff member’s email; defaults to empty string. |
| Phone | `string Phone { get; set; }` | Staff member’s phone; defaults to empty string. |
| Position | `string Position { get; set; }` | Staff member’s job title/role; defaults to empty string. |
| HireDate | `DateTime HireDate { get; set; }` | Date the staff member was hired. |
| IsActive | `bool IsActive { get; set; }` | Indicates whether the staff member is currently active. |

## 5. Key Behaviors & Business Rules
- Simple DTO: contains no methods, validation logic, or side effects.
- String properties are initialized to `string.Empty`, avoiding null references on read.
- Value types (`Guid`, `DateTime`, `bool`) rely on default CLR values unless explicitly set.
- No exception handling, caching, or event publishing within this type.

## 6. Connections
- Intended for use by the application layer to transfer staff data between layers (e.g., mapping to/from domain entities or API contracts).
- No direct interactions with other classes or services in this file.## 1. Overview
`UpdateBookCategoryDto` is a simple Data Transfer Object (DTO) used to carry book category update data across application boundaries. It encapsulates two fields—name and description—typically used by the application layer to accept or pass update payloads.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Name | `string Name { get; set; }` | The display name of the book category; defaults to empty string. |
| Description | `string Description { get; set; }` | A textual description of the book category; defaults to empty string. |

## 5. Key Behaviors & Business Rules
- Properties are initialized to empty strings to avoid nulls (`string.Empty`).
- No validation, transformation, or business logic is present.
- No exception handling, caching, or side effects; this is a pure data container.

## 6. Connections
- No explicit interactions shown. As a DTO in the `Library.Application.DTOs` namespace, it is intended to be used by application-layer components that handle book category update operations.# Overview
`UpdateBookDto` is a data transfer object in the application layer used to carry book update data across boundaries (e.g., from API/UI to application services). It encapsulates mutable fields relevant to updating a book’s metadata and availability without embedding domain logic.

# Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| Title | `string Title { get; set; }` | The book’s title to set during update. |
| Author | `string Author { get; set; }` | The book’s author to set during update. |
| ISBN | `string ISBN { get; set; }` | The book’s ISBN identifier to set during update. |
| PublishedYear | `int PublishedYear { get; set; }` | The book’s publication year to set during update. |
| IsAvailable | `bool IsAvailable { get; set; }` | Indicates if the book should be marked available. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Optional category identifier to associate with the book. |

# Key Behaviors & Business Rules
- No validations or business rules are implemented in this DTO.
- Default values:
  - `Title`, `Author`, `ISBN` default to empty strings.
  - `BookCategoryId` is nullable with no default.
- The class contains only auto-properties; no side effects, exceptions, or logic.

# Connections
- Intended for use by application-layer handlers/services that process book update requests.
- Likely consumed by API controllers or UI bindings when updating book entities and passed downstream to domain or persistence layers.## 1. Overview
`UpdateCustomerDto` is a Data Transfer Object (DTO) used to carry customer update data across application boundaries. It encapsulates mutable customer fields such as name, contact details, address, and active status. This type resides in the application layer (DTOs) and is intended for API/application service interactions rather than domain logic.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| FirstName | `string FirstName { get; set; }` | Customer’s given name; defaults to empty string. |
| LastName | `string LastName { get; set; }` | Customer’s family name; defaults to empty string. |
| Email | `string Email { get; set; }` | Customer’s email address; defaults to empty string. |
| Phone | `string Phone { get; set; }` | Customer’s phone number; defaults to empty string. |
| Address | `string Address { get; set; }` | Customer’s postal address; defaults to empty string. |
| IsActive | `bool IsActive { get; set; }` | Indicates whether the customer is active. |

## 5. Key Behaviors & Business Rules
- None. This is a simple DTO with no validation, logic, or side effects. All string properties default to `string.Empty`.

## 6. Connections
- No explicit interactions are defined in this file. The class is positioned for use by application services or API endpoints that handle customer update operations.## 1. Overview
`UpdateStaffDto` is a simple Data Transfer Object (DTO) used to carry staff update data across application boundaries. It encapsulates user-editable fields for a staff member without containing any domain logic. This type fits in the Application layer (DTOs) and is typically used by API endpoints or application handlers to receive/update staff data.

## 2. Type Info
- Type: `class`
- Inherits: `object` (implicit)
- Implements: None
- Namespace: `Library.Application.DTOs`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| FirstName | `string FirstName { get; set; }` | Staff member’s first name. Defaults to empty string. |
| LastName | `string LastName { get; set; }` | Staff member’s last name. Defaults to empty string. |
| Email | `string Email { get; set; }` | Staff member’s email address. Defaults to empty string. |
| Phone | `string Phone { get; set; }` | Staff member’s phone number. Defaults to empty string. |
| Position | `string Position { get; set; }` | Staff member’s job title/position. Defaults to empty string. |
| IsActive | `bool IsActive { get; set; }` | Indicates if the staff member is active. |

## 5. Key Behaviors & Business Rules
- All string properties are initialized to `string.Empty`, reducing null-handling overhead for consumers.
- No validation, transformation, or side effects are present.
- No methods, events, or exception handling; this type purely models data for updates.

## 6. Connections
- Intended for use by the Application/API layer to receive or send update payloads for staff entities.
- Does not directly interact with other classes or services; mapping to domain entities or persistence models would occur elsewhere in the application.## 1. Overview
Provides a single extension point to register application-layer services into the dependency injection container. Centralizes service wiring for the Library application’s Application layer, ensuring that interfaces are mapped to their concrete implementations with a scoped lifetime.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| AddApplication | `public static IServiceCollection AddApplication(this IServiceCollection services)` | Registers application services (`IBookService`, `IBookCategoryService`, `IStaffService`, `ICustomerService`) with scoped lifetimes and returns the modified `IServiceCollection`. |

## 5. Key Behaviors & Business Rules
- Registers the following interface-to-implementation mappings using `AddScoped`:
  - `IBookService` → `BookService`
  - `IBookCategoryService` → `BookCategoryService`
  - `IStaffService` → `StaffService`
  - `ICustomerService` → `CustomerService`
- Uses scoped lifetimes, meaning one instance per request scope in typical web applications.
- No input validation, exception handling, or side effects beyond DI configuration.
- Returns the same `IServiceCollection` to enable fluent configuration chaining.

## 6. Connections
- Downstream dependencies (registered services): `Library.Application.Interfaces.IBookService`, `IBookCategoryService`, `IStaffService`, `ICustomerService` mapped to `Library.Application.Services.BookService`, `BookCategoryService`, `StaffService`, `CustomerService`.
- Framework integration: relies on `Microsoft.Extensions.DependencyInjection.IServiceCollection` and extension methods for DI registration.
- Intended to be invoked by any composition root that configures `IServiceCollection` (e.g., application startup) to include Application-layer services.# IBookCategoryService

## 1. Overview
Defines the application-layer contract for managing book categories using asynchronous CRUD operations. It exposes methods that operate with DTOs, enabling higher layers to interact with book category data without coupling to persistence or domain entities. Fits within the Application layer as an interface for service implementations.

## 2. Type Info
- Type: `interface`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Retrieves a single category by its identifier; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Retrieves all categories. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Creates a new category from the provided data and returns the created DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Updates an existing category identified by id with the provided data. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes the category identified by id. |

## 5. Key Behaviors & Business Rules
- All operations are asynchronous (`Task`-based).
- Uses DTOs (`BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`) to decouple service contract from domain/persistence models.
- `GetByIdAsync` can return `null`, signaling absence of the requested category.
- `UpdateAsync` and `DeleteAsync` return `Task` without a result, indicating side-effect operations with no direct return value.
- No implementation details, validations, or exception handling are present in this interface.

## 6. Connections
- Consumes DTOs from `Library.Application.DTOs`: `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.
- Intended to be implemented by an application service that likely coordinates with domain and data access layers; specific downstream dependencies are not shown in this file.
- Expected upstream consumers include other application components or presentation/API layers that require category management via DTOs.# 1. Overview
`IBookService` defines the application-layer contract for managing books. It specifies asynchronous operations for retrieving, creating, updating, and deleting book data, as well as querying available books. This interface belongs to the Application layer (API/use-case boundary) and is intended to be implemented by services that coordinate domain and data access logic.

# 2. Type Info
- Type: `interface`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Interfaces`

# 3. Dependencies
No external dependencies.

# 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Retrieves a book by its identifier; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Retrieves all books. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Retrieves books considered “available.” |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Creates a new book and returns its representation. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Updates an existing book by identifier. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a book by identifier. |

# 5. Key Behaviors & Business Rules
- All operations are asynchronous via `Task`, enabling non-blocking I/O.
- `GetByIdAsync` returns a nullable `BookDto?` to signal absence without exceptions.
- `UpdateAsync` and `DeleteAsync` return `Task` (no payload), implying side-effect operations.
- DTO usage separates transport shapes: `BookDto` for reads; `CreateBookDto` and `UpdateBookDto` for writes.

# 6. Connections
- Uses DTOs from `Library.Application.DTOs`: `BookDto`, `CreateBookDto`, `UpdateBookDto`.
- Intended to be implemented by a service in the Application layer; consumers are likely higher-level application components (e.g., API endpoints or handlers) that require book-related operations.## 1. Overview
Defines the application-layer contract for customer-related operations. It exposes asynchronous CRUD-style methods and a query for active customers using DTOs, enabling separation between the API/UI and underlying domain/infrastructure implementations. Fits in the Application layer as an interface to orchestrate customer workflows.

## 2. Type Info
- Type: `interface`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Retrieves a customer by identifier; returns `null` if not found. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Retrieves all customers. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Retrieves customers considered “active.” |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Creates a new customer from the provided data and returns the created customer DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Updates an existing customer identified by ID with the provided data. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes the customer identified by ID. |

## 5. Key Behaviors & Business Rules
- All operations are asynchronous and return `Task`-based results.
- `GetByIdAsync` explicitly allows a not-found outcome via nullable `CustomerDto?`.
- Uses DTOs (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`) to decouple the service contract from domain entities.
- Presence of `GetActiveCustomersAsync` establishes “active” as a first-class filter in the contract; specific criteria are not defined here.
- `UpdateAsync` and `DeleteAsync` return no payload, signaling command-style operations.

## 6. Connections
- Consumes and produces DTOs from `Library.Application.DTOs`: `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`.
- Intended to be implemented by a concrete service that interacts with domain and/or data access layers (not shown in this file).
- Likely invoked by higher-level application components (e.g., API controllers or handlers) that require customer management operations.# Overview
`IStaffService` defines the application-layer contract for managing staff entities in a library system. It exposes asynchronous CRUD and query operations using DTOs, encapsulating staff-related business use cases within the Application layer and decoupling callers from data access details.

# Type Info
- Type: `interface`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Interfaces`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Retrieves a staff member by unique identifier; returns `null` if not found. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Returns all staff members. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Returns staff members considered “active.” |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Creates a new staff member and returns the created DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Updates an existing staff member by ID. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a staff member by ID. |

# Key Behaviors & Business Rules
- All operations are asynchronous via `Task`, suitable for I/O-bound operations.
- The API uses DTOs (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`), indicating separation between application contracts and domain/entities.
- No explicit validations, exceptions, or side effects are defined in the interface; such behavior is determined by implementations.

# Connections
- Uses DTO types from `Library.Application.DTOs`: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto`.
- Designed for the Application layer; implementations likely coordinate with repositories or infrastructure, but none are specified in this interface.## 1. Overview
`BookCategoryMappings` centralizes conversions between domain entity `BookCategory` and its corresponding application DTOs. It supports creating DTOs from entities, creating new entities from create-DTOs, and updating existing entities from update-DTOs. This mapping utility resides in the Application layer, facilitating separation between domain models and API-facing contracts.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Mappings`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| ToDto | `BookCategoryDto ToDto(this BookCategory category)` | Maps a `BookCategory` entity to a `BookCategoryDto`. |
| ToEntity | `BookCategory ToEntity(this CreateBookCategoryDto dto)` | Creates a new `BookCategory` entity from a `CreateBookCategoryDto`, generating a new `Id`. |
| UpdateEntity | `void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)` | Updates an existing `BookCategory` entity’s `Name` and `Description` from an `UpdateBookCategoryDto`. |

## 5. Key Behaviors & Business Rules
- Uses extension methods to provide fluent conversion on `BookCategory`, `CreateBookCategoryDto`, and `UpdateBookCategoryDto`.
- `ToEntity` assigns a new identifier via `Guid.NewGuid()`; the ID is not sourced from the DTO.
- `UpdateEntity` mutates the provided `BookCategory` instance in place (side effect).
- No null checks or validation are performed; callers must ensure non-null inputs and valid state.
- No exception handling, logging, or caching is implemented.
- Field mapping is direct: `Name` and `Description` are copied verbatim between DTOs and entity.

## 6. Connections
- Downstream: `Library.Domain.Entities.BookCategory`.
- Downstream: `Library.Application.DTOs.BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto`.
- Intended usage within the Application layer (e.g., handlers/services) to translate between domain entities and DTOs for API or other application boundaries.## 1. Overview
Provides mapping extensions between domain entity `Book` and application DTOs (`BookDto`, `CreateBookDto`, `UpdateBookDto`). It centralizes transformation logic for creating, reading, and updating books. Lives in the Application layer as a mapping utility bridging Domain and DTO models.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Mappings`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| ToDto | `BookDto ToDto(this Book book)` | Maps a domain `Book` to a `BookDto`, including the optional `BookCategoryName`. |
| ToEntity | `Book ToEntity(this CreateBookDto dto)` | Creates a new `Book` domain entity from a `CreateBookDto`, assigning a new `Guid` Id and defaulting `IsAvailable` to true. |
| UpdateEntity | `void UpdateEntity(this UpdateBookDto dto, Book book)` | Updates an existing `Book` entity’s fields from an `UpdateBookDto`. |

## 5. Key Behaviors & Business Rules
- Generates a new identifier: `ToEntity` sets `Id = Guid.NewGuid()` for newly created `Book` entities.
- Sets default availability: `ToEntity` initializes `IsAvailable = true` regardless of input.
- Null-safe category name mapping: `ToDto` uses `book.BookCategory?.Name` to avoid null reference when category is not loaded.
- In-place mutation: `UpdateEntity` directly mutates the provided `Book` instance with values from `UpdateBookDto`.
- No validation or exception handling is performed; assumes DTOs contain valid data and the `Book` instance in `UpdateEntity` is non-null.

## 6. Connections
- Downstream: Uses domain entity `Library.Domain.Entities.Book` and its navigation `BookCategory` (read-only for `Name`).
- Upstream/DTOs: Maps to/from `Library.Application.DTOs.BookDto`, `CreateBookDto`, and `UpdateBookDto`.
- Intended usage by application services or handlers that translate between domain models and API-facing DTOs.## 1. Overview
Provides extension methods to map between customer DTOs and the domain `Customer` entity. It centralizes translation logic for create, read, and update flows, ensuring consistent field population. This lives in the application layer (mappings) bridging API/DTOs and domain models.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Mappings`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| ToDto | `CustomerDto ToDto(this Customer customer)` | Maps a domain `Customer` to a `CustomerDto`. |
| ToEntity | `Customer ToEntity(this CreateCustomerDto dto)` | Creates a new domain `Customer` from a `CreateCustomerDto`. |
| UpdateEntity | `void UpdateEntity(this UpdateCustomerDto dto, Customer customer)` | Updates an existing `Customer` with values from an `UpdateCustomerDto`. |

## 5. Key Behaviors & Business Rules
- ToDto:
  - Copies scalar fields directly: `Id`, `FirstName`, `LastName`, `Email`, `Phone`, `Address`, `MembershipNumber`, `RegisteredDate`, `IsActive`.
- ToEntity:
  - Generates a new `Id` using `Guid.NewGuid()`.
  - Sets `MembershipNumber` to an uppercase 10-character string derived from a new GUID: `Guid.NewGuid().ToString("N")[..10].ToUpper()`.
  - Sets `RegisteredDate` to `DateTime.UtcNow`.
  - Initializes `IsActive` to `true`.
  - Copies `FirstName`, `LastName`, `Email`, `Phone`, `Address` from the create DTO.
- UpdateEntity:
  - Overwrites `FirstName`, `LastName`, `Email`, `Phone`, `Address`, and `IsActive` on the target entity from the update DTO.
- No validation, error handling, or null checks are performed; consumers must ensure non-null inputs and valid data.
- No side effects beyond entity field assignments; no I/O, logging, or event publishing.

## 6. Connections
- Upstream: Expected to be called by application/services or API controllers handling customer create, read, and update operations.
- Downstream: Interacts with `Library.Domain.Entities.Customer` and DTOs `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto` from `Library.Application.DTOs`.## 1. Overview
`StaffMappings` provides extension methods to convert between domain entity `Staff` and application-layer DTOs (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`). It centralizes mapping logic in the Application layer to keep controllers/handlers thin and ensure consistent transformations across the app.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Application.Mappings`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| ToDto | `StaffDto ToDto(this Staff staff)` | Maps a `Staff` domain entity to a `StaffDto`, copying all exposed fields. |
| ToEntity | `Staff ToEntity(this CreateStaffDto dto)` | Creates a new `Staff` entity from a `CreateStaffDto`; generates a new `Id` and sets `IsActive = true`. |
| UpdateEntity | `void UpdateEntity(this UpdateStaffDto dto, Staff staff)` | Mutates an existing `Staff` entity with values from `UpdateStaffDto` (excludes `HireDate` and `Id`). |

## 5. Key Behaviors & Business Rules
- Mapping:
  - `ToDto` copies `Id`, `FirstName`, `LastName`, `Email`, `Phone`, `Position`, `HireDate`, `IsActive` from entity to DTO.
  - `ToEntity` initializes a new `Staff` with values from `CreateStaffDto`, sets a new `Guid` for `Id`, sets `IsActive` to `true`, and copies `HireDate`.
  - `UpdateEntity` updates mutable fields (`FirstName`, `LastName`, `Email`, `Phone`, `Position`, `IsActive`) on an existing entity; it does not modify `Id` or `HireDate`.
- No validation or null checks are performed; callers must ensure non-null inputs and valid data.
- No exception handling, caching, or retries are implemented.
- `UpdateEntity` has side effects by mutating the provided `Staff` instance.

## 6. Connections
- Downstream types used:
  - `Library.Domain.Entities.Staff`
  - `Library.Application.DTOs.StaffDto`
  - `Library.Application.DTOs.CreateStaffDto`
  - `Library.Application.DTOs.UpdateStaffDto`
- Likely consumed by application services/handlers/controllers that translate between domain entities and DTOs (not shown in this file).## 1. Overview
`BookCategoryService` is an application-layer service that provides CRUD operations for book categories using DTOs. It coordinates persistence via a domain repository and performs mapping between domain entities and application DTOs. This service fits in the Application layer, mediating between API/UI callers and the Domain layer.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `Library.Application.Interfaces.IBookCategoryService`
- Namespace: `Library.Application.Services`

## 3. Dependencies
- `Library.Domain.Interfaces.IBookCategoryRepository` — Data access for book category entities (get, add, update, delete).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<BookCategoryDto?> GetByIdAsync(Guid id)` | Retrieves a category by ID and maps it to a DTO; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<BookCategoryDto>> GetAllAsync()` | Retrieves all categories and maps them to DTOs. |
| CreateAsync | `Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)` | Creates a new category from a create DTO, persists it, and returns the created DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)` | Loads a category by ID, applies updates from the update DTO, and persists changes; throws if not found. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a category by ID via the repository. |

## 5. Key Behaviors & Business Rules
- Uses mapping extensions (`ToDto`, `ToEntity`, `UpdateEntity`) from `Library.Application.Mappings` to translate between entities and DTOs.
- Update path enforces existence: throws `KeyNotFoundException` when the target category is not found.
- No explicit validation, caching, or retry logic present.
- All operations are asynchronous and delegate persistence to the repository.
- Create returns the DTO of the newly added entity after repository add.

## 6. Connections
- Downstream: `IBookCategoryRepository` (domain/data access) for persistence.
- Mapping: Extension methods in `Library.Application.Mappings` for entity/DTO conversion.
- Data Contracts: Uses `BookCategoryDto`, `CreateBookCategoryDto`, `UpdateBookCategoryDto` from `Library.Application.DTOs`.
- Upstream: Likely called by API controllers or other application services implementing `IBookCategoryService` (exact callers not shown).## 1. Overview
`BookService` is an application-layer service that implements `IBookService` to orchestrate book-related operations. It bridges domain entities and application DTOs using mapping extensions, delegating persistence to a domain repository. This service fits in the application/services layer, exposing CRUD and query operations for books.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `Library.Application.Interfaces.IBookService`
- Namespace: `Library.Application.Services`

## 3. Dependencies
- `IBookRepository` — Repository abstraction for book persistence and queries.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<BookDto?> GetByIdAsync(Guid id)` | Retrieves a book by ID and maps it to a DTO; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<BookDto>> GetAllAsync()` | Fetches all books and maps them to DTOs. |
| GetAvailableBooksAsync | `Task<IEnumerable<BookDto>> GetAvailableBooksAsync()` | Fetches available books only and maps them to DTOs. |
| CreateAsync | `Task<BookDto> CreateAsync(CreateBookDto createBookDto)` | Creates a new book from a create DTO, persists it, and returns its DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)` | Loads a book by ID, applies updates from DTO, and persists changes. Throws if not found. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a book by ID via the repository. |

## 5. Key Behaviors & Business Rules
- Uses mapping extensions (`ToDto`, `ToEntity`, `UpdateEntity`) to convert between domain entities and DTOs.
- `UpdateAsync` throws `KeyNotFoundException` when the target book does not exist.
- Read operations return DTOs; `GetByIdAsync` explicitly supports a null result.
- All operations are asynchronous and delegate persistence to `IBookRepository`.
- No explicit validation, caching, or retry logic present.

## 6. Connections
- Downstream: `Library.Domain.Interfaces.IBookRepository` for data access; `Library.Application.Mappings` for entity/DTO mapping; `Library.Application.DTOs` for data transfer types.
- Upstream: Consumed via `Library.Application.Interfaces.IBookService` by callers in higher layers (e.g., application/API).## 1. Overview
`CustomerService` is an application-layer service that orchestrates customer-related operations, acting as a bridge between domain repositories and application DTOs. It encapsulates repository access and mapping logic, providing a clean API for higher layers to manage customers asynchronously.

## 2. Type Info
- Type: `class`
- Inherits: `object`
- Implements: `ICustomerService`
- Namespace: `Library.Application.Services`

## 3. Dependencies
- `ICustomerRepository` — Provides data access operations for customer entities (fetch, add, update, delete).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<CustomerDto?> GetByIdAsync(Guid id)` | Fetches a customer by ID and maps it to a DTO; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<CustomerDto>> GetAllAsync()` | Retrieves all customers and maps them to DTOs. |
| GetActiveCustomersAsync | `Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync()` | Retrieves active customers and maps them to DTOs. |
| CreateAsync | `Task<CustomerDto> CreateAsync(CreateCustomerDto createDto)` | Creates a new customer from a create DTO, persists it, and returns the created DTO. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateCustomerDto updateDto)` | Updates an existing customer by ID using an update DTO; throws if not found. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a customer by ID. |

## 5. Key Behaviors & Business Rules
- All operations are asynchronous and delegate persistence to `ICustomerRepository`.
- Mapping between domain entities and DTOs is handled via extension methods: `ToDto()`, `ToEntity()`, and `UpdateEntity(...)`.
- `UpdateAsync` enforces existence: throws `KeyNotFoundException` with the missing ID if the customer does not exist before updating.
- No explicit validation, caching, retries, or transaction handling present in this class.

## 6. Connections
- Downstream: `Library.Domain.Interfaces.ICustomerRepository` for data access.
- Mapping: `Library.Application.Mappings` extension methods for entity/DTO transformations.
- Data contracts: `Library.Application.DTOs` (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`).
- Upstream callers interact via `ICustomerService` (not shown here), typically from higher application layers.# StaffService Summary

## 1. Overview
`StaffService` is an application-layer service that orchestrates staff-related operations, bridging domain repositories and DTOs. It exposes asynchronous CRUD-style methods and active-staff retrieval, handling mapping between entities and DTOs. It fits in the Application layer (`Library.Application.Services`) and delegates persistence to a domain repository.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `Library.Application.Interfaces.IStaffService`
- Namespace: `Library.Application.Services`

## 3. Dependencies
- `Library.Domain.Interfaces.IStaffRepository` — Provides persistence operations for staff entities.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<StaffDto?> GetByIdAsync(Guid id)` | Retrieves a staff member by ID and maps it to `StaffDto`; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<StaffDto>> GetAllAsync()` | Retrieves all staff and maps them to `StaffDto`. |
| GetActiveStaffAsync | `Task<IEnumerable<StaffDto>> GetActiveStaffAsync()` | Retrieves active staff only and maps them to `StaffDto`. |
| CreateAsync | `Task<StaffDto> CreateAsync(CreateStaffDto createDto)` | Creates a new staff entity from `CreateStaffDto`, persists it, and returns the created `StaffDto`. |
| UpdateAsync | `Task UpdateAsync(Guid id, UpdateStaffDto updateDto)` | Loads an existing staff entity by ID, applies updates from `UpdateStaffDto`, and persists changes. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a staff entity by ID. |

## 5. Key Behaviors & Business Rules
- Uses mapping extensions (`ToDto`, `ToEntity`, `UpdateEntity`) from `Library.Application.Mappings` to convert between entities and DTOs.
- Throws `KeyNotFoundException` with a specific message if `UpdateAsync` cannot find the staff entity by ID.
- All operations are asynchronous and delegate persistence to `IStaffRepository`.
- No explicit validation, caching, or retry logic is present in this service.

## 6. Connections
- Downstream: `Library.Domain.Interfaces.IStaffRepository` for data access; mapping extensions in `Library.Application.Mappings`.
- Data contracts: `Library.Application.DTOs` (`StaffDto`, `CreateStaffDto`, `UpdateStaffDto`).
- Upstream callers are not defined in this file (likely other application components that require staff operations).# Overview
Represents a domain entity for a library book within the domain layer. It encapsulates core metadata about a book and maintains an optional association to a book category. Intended for use where domain models are needed (e.g., application/domain logic and data persistence mappings).

# Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Domain.Entities`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the book. |
| Title | `string Title { get; set; }` | Book title; defaults to empty string. |
| Author | `string Author { get; set; }` | Book author; defaults to empty string. |
| ISBN | `string ISBN { get; set; }` | International Standard Book Number; defaults to empty string. |
| PublishedYear | `int PublishedYear { get; set; }` | Year the book was published. |
| IsAvailable | `bool IsAvailable { get; set; }` | Availability flag; defaults to true. |
| BookCategoryId | `Guid? BookCategoryId { get; set; }` | Optional foreign key to the book’s category. |
| BookCategory | `BookCategory? BookCategory { get; set; }` | Optional navigation reference to the related category. |

# Key Behaviors & Business Rules
- Default values:
  - `Title`, `Author`, and `ISBN` initialize to empty strings.
  - `IsAvailable` initializes to `true`.
- `BookCategoryId` and `BookCategory` are nullable, indicating the category relationship is optional.
- No validation, exception handling, or business logic is implemented in this type.

# Connections
- Downstream: Holds an optional relationship to `BookCategory` via `BookCategoryId` and `BookCategory`.
- Upstream callers: Not specified in this file; typical consumers would be domain/application services or data access layers referencing domain entities.# Overview
`BookCategory` is a domain entity representing a categorization for books, holding an identifier, a name, and a description. It provides a collection-based association to related `Book` entities. This type resides in the domain layer and models core domain data without behavior.

# Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Domain.Entities`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the category. |
| Name | `string Name { get; set; }` | Human-readable category name; initialized to empty string. |
| Description | `string Description { get; set; }` | Optional descriptive text; initialized to empty string. |
| Books | `ICollection<Book> Books { get; set; }` | Navigation collection of associated books; initialized to an empty collection. |

# Key Behaviors & Business Rules
- Properties `Name` and `Description` are initialized to `string.Empty`, preventing null values by default.
- `Books` is initialized to an empty collection to avoid null reference issues when adding or enumerating related `Book` instances.
- No validation, exception handling, or business logic is implemented in this type.
- No methods; the class serves as a simple data container (entity) with a navigation relationship.

# Connections
- Downstream: References `Book` via `ICollection<Book> Books`, indicating a one-to-many relationship from category to books.
- Upstream: Likely consumed by application layers that manage or query domain entities, but specific callers are not evident from this file.## 1. Overview
`Customer` is a domain entity representing a library customer’s core profile and membership state. It encapsulates identifying information and contact details used within the domain layer. This class is likely persisted and consumed by application services and data access components, but the file itself contains no persistence or behavior logic.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: None
- Namespace: `Library.Domain.Entities`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier of the customer. |
| FirstName | `string FirstName { get; set; }` | Customer’s first name. Defaults to empty string. |
| LastName | `string LastName { get; set; }` | Customer’s last name. Defaults to empty string. |
| Email | `string Email { get; set; }` | Customer’s email address. Defaults to empty string. |
| Phone | `string Phone { get; set; }` | Customer’s phone number. Defaults to empty string. |
| Address | `string Address { get; set; }` | Customer’s mailing address. Defaults to empty string. |
| MembershipNumber | `string MembershipNumber { get; set; }` | Library membership number. Defaults to empty string. |
| RegisteredDate | `DateTime RegisteredDate { get; set; }` | Date the customer registered. |
| IsActive | `bool IsActive { get; set; }` | Indicates whether the membership is active. Defaults to `true`. |

## 5. Key Behaviors & Business Rules
- All string properties are initialized to `string.Empty`, avoiding nulls by default.
- `IsActive` defaults to `true`, implying new customers are active unless explicitly deactivated.
- No validation, invariants, or domain behavior is implemented in this class.
- No exception handling, caching, or side effects; this is a simple data container (an anemic domain model).

## 6. Connections
- Defined in the domain layer (`Library.Domain.Entities`), intended for use by application services, repositories, and possibly API DTO mapping.
- No explicit interactions or references to other classes/services are present in this file.## 1. Overview
Represents a staff member within the domain model, encapsulating identity, contact details, role, employment dates, and active status. This class resides in the Domain layer (Entities) and serves as a simple data container for persistence and business operations that reference staff information.

## 2. Type Info
- Type: `class`
- Inherits: `object`
- Implements: None
- Namespace: `Library.Domain.Entities`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Id | `Guid Id { get; set; }` | Unique identifier for the staff member. |
| FirstName | `string FirstName { get; set; }` | Staff member’s first name; defaults to empty string. |
| LastName | `string LastName { get; set; }` | Staff member’s last name; defaults to empty string. |
| Email | `string Email { get; set; }` | Staff member’s email address; defaults to empty string. |
| Phone | `string Phone { get; set; }` | Staff member’s phone number; defaults to empty string. |
| Position | `string Position { get; set; }` | Staff member’s job title or role; defaults to empty string. |
| HireDate | `DateTime HireDate { get; set; }` | Date the staff member was hired. |
| IsActive | `bool IsActive { get; set; }` | Indicates whether the staff member is currently active; defaults to true. |

## 5. Key Behaviors & Business Rules
- Acts as a simple entity/DTO with auto-implemented properties.
- Default values: `FirstName`, `LastName`, `Email`, `Phone`, `Position` default to `string.Empty`; `IsActive` defaults to `true`.
- No validations, side effects, or exception handling present.

## 6. Connections
- Standalone domain entity; no direct interactions with other classes or services are shown in this file.
- Upstream callers and downstream dependencies are not evident from the code.## 1. Overview
`IBookCategoryRepository` defines repository operations for the `BookCategory` aggregate in the domain layer. It extends a generic repository interface to add category-specific queries, such as lookup by name and fetching a category with its related books. This interface belongs to the domain abstraction layer, intended to be implemented by the infrastructure/data access layer.

## 2. Type Info
- Type: `interface`
- Inherits: `IRepository<BookCategory>`
- Implements: —
- Namespace: `Library.Domain.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Retrieves a category by exact name, or returns null if not found. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Retrieves a category by ID including its related books, or returns null if not found. |

Note: Additional members may be inherited from `IRepository<BookCategory>` (not shown in this file).

## 5. Key Behaviors & Business Rules
- This is an abstraction only; no implementation details, validations, or side effects are present in this file.
- Asynchronous methods return nullable results to represent “not found” without throwing exceptions.

## 6. Connections
- Uses `Library.Domain.Entities.BookCategory`.
- Extends `IRepository<BookCategory>` (presumably a generic repository abstraction within the same domain).
- Intended to be implemented by data access/infrastructure components that provide persistence for `BookCategory`.## 1. Overview
Defines a domain-level repository contract for working with `Book` entities. It extends a generic repository to add book-specific queries, fitting into the Domain layer’s abstraction over data access. Implementations are expected to reside in the infrastructure layer and fulfill these contracts against a data store.

## 2. Type Info
- Type: `interface`
- Inherits: `IRepository<Book>`
- Implements: —
- Namespace: `Library.Domain.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Retrieves all books that are currently available. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Retrieves a single book by its ISBN; returns null if not found. |

Note: This interface also includes all members inherited from `IRepository<Book>`.

## 5. Key Behaviors & Business Rules
- As an interface, it declares asynchronous read operations; no implementation details or side effects are present here.
- The `GetByISBNAsync` method explicitly allows for absence (`null`) when a match is not found.

## 6. Connections
- Upstream types: Expected to be consumed by application or domain services needing access to `Book` data.
- Downstream types: Depends on `Library.Domain.Entities.Book` and extends `IRepository<Book>` (not shown here), which defines base repository operations for `Book`. Implementations will reside outside the domain (e.g., infrastructure) to interact with the data source.## 1. Overview
`ICustomerRepository` defines the domain-level contract for retrieving `Customer` entities via repository patterns. It extends a generic repository for `Customer` and adds customer-specific lookup operations. This interface resides in the domain layer, enabling application components to depend on abstractions rather than concrete data access implementations.

## 2. Type Info
- Type: `interface`
- Inherits: `IRepository<Customer>`
- Implements: —
- Namespace: `Library.Domain.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | Asynchronously retrieves a customer by email; returns `null` if not found. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Asynchronously retrieves a customer by membership number; returns `null` if not found. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Asynchronously retrieves all active customers. |

## 5. Key Behaviors & Business Rules
- All operations are asynchronous (`Task`-based).
- Methods that fetch a single entity return `Customer?`, indicating the customer may not exist (`null` result).
- The interface adds domain-specific queries (by email, by membership number, active customers) on top of generic repository capabilities.

## 6. Connections
- Upstream/Consumers: Any domain/application components that require customer data via the repository abstraction.
- Downstream/Dependencies: Extends `IRepository<Customer>` and uses the `Customer` entity from `Library.Domain.Entities`. Implementations will fulfill these contracts to access underlying persistence.## 1. Overview
Defines a generic repository contract for asynchronous CRUD operations over aggregate/entities. It exists to decouple domain/application code from specific data access implementations by exposing a minimal persistence abstraction. Located in the domain layer (Interfaces), it serves as an architectural boundary for infrastructure-backed repositories.

## 2. Type Info
- Type: `interface`
- Inherits: None
- Implements: None
- Namespace: `Library.Domain.Interfaces`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<T?> GetByIdAsync(Guid id)` | Retrieves an entity by its identifier, or null if not found. |
| GetAllAsync | `Task<IEnumerable<T>> GetAllAsync()` | Retrieves all entities. |
| AddAsync | `Task AddAsync(T entity)` | Adds a new entity. |
| UpdateAsync | `Task UpdateAsync(T entity)` | Updates an existing entity. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes an entity by its identifier. |

Note: `T` is constrained to `class`.

## 5. Key Behaviors & Business Rules
- Asynchronous API surface (`Task`-based) for all operations, enabling non-blocking I/O in implementations.
- Generic type parameter `T` constrained to reference types (`class`).
- Identifiers are represented as `Guid` for retrieval and deletion.
- No exception behavior, validation, caching, or side effects are defined at the interface level; these are left to implementations.

## 6. Connections
- Upstream: Domain/application services or handlers that depend on `IRepository<T>` for persistence operations without coupling to a specific data store.
- Downstream: Concrete repository implementations in the infrastructure layer that fulfill this contract to interact with the underlying data source for the entity type `T`.# Overview
Defines a repository interface for `Staff` entities in the domain layer, extending a generic repository abstraction. It declares query operations specific to staff users, supporting asynchronous retrieval by email and filtering active staff. This fits in the domain/data access boundary, enabling implementations in the infrastructure layer.

# Type Info
- Type: `interface`
- Inherits: `IRepository<Staff>`
- Implements: —
- Namespace: `Library.Domain.Interfaces`

# Dependencies
No external dependencies.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByEmailAsync | `Task<Staff?> GetByEmailAsync(string email)` | Asynchronously retrieves a `Staff` entity by its email, or null if not found. |
| GetActiveStaffAsync | `Task<IEnumerable<Staff>> GetActiveStaffAsync()` | Asynchronously retrieves all active `Staff` entities. |

Note: Also inherits all members from `IRepository<Staff>`.

# Key Behaviors & Business Rules
- Contract-only; no implementation provided in this file.
- Methods are asynchronous, indicating I/O-bound data access patterns.
- `GetByEmailAsync` should return `null` when no matching staff is found (nullable result).
- `GetActiveStaffAsync` implies a domain concept of “active” status on `Staff` entities; the filtering criteria are defined by implementations.

# Connections
- Uses `Library.Domain.Entities.Staff`.
- Extends `IRepository<Staff>`, indicating integration with a generic repository pattern for CRUD and querying.
- Intended for implementation by an infrastructure data access class (e.g., EF Core repository) and consumption by application/domain services that need staff lookup and active staff enumeration.## 1. Overview
`LibraryDbContext` is an Entity Framework Core context that maps domain entities to the underlying database. It configures entity schemas, relationships, constraints, and indexes for the library domain. This class resides in the infrastructure/data access layer and serves as the entry point for CRUD operations via EF Core.

## 2. Type Info
- Type: `class`
- Inherits: `Microsoft.EntityFrameworkCore.DbContext`
- Implements: None
- Namespace: `Library.Infrastructure.Data`

## 3. Dependencies
- `DbContextOptions<LibraryDbContext>` — EF Core configuration options used to configure the context (e.g., provider, connection string).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Constructor | `LibraryDbContext(DbContextOptions<LibraryDbContext> options)` | Initializes the context with EF Core options. |
| Books | `DbSet<Book> Books { get; }` | DbSet for `Book` entities. |
| BookCategories | `DbSet<BookCategory> BookCategories { get; }` | DbSet for `BookCategory` entities. |
| Staff | `DbSet<Staff> Staff { get; }` | DbSet for `Staff` entities. |
| Customers | `DbSet<Customer> Customers { get; }` | DbSet for `Customer` entities. |
| OnModelCreating (protected) | `protected override void OnModelCreating(ModelBuilder modelBuilder)` | Configures entity keys, properties, relationships, and indexes. |

## 5. Key Behaviors & Business Rules
- `Book`:
  - Required: `Title`, `Author`, `ISBN`; max lengths 200, 150, 20 respectively.
  - Unique index on `ISBN`.
  - Relationship: optional many-to-one with `BookCategory` (`BookCategoryId`), delete behavior `SetNull`.
- `BookCategory`:
  - Required: `Name` (max 100); `Description` max 500.
  - Unique index on `Name`.
- `Staff`:
  - Required: `FirstName`, `LastName` (max 100), `Email` (max 200), `Position` (max 100).
  - Optional: `Phone` (max 20).
  - Unique index on `Email`.
- `Customer`:
  - Required: `FirstName`, `LastName` (max 100), `Email` (max 200), `MembershipNumber` (max 50).
  - Optional: `Phone` (max 20), `Address` (max 500).
  - Unique indexes on `Email` and `MembershipNumber`.
- Leverages EF Core fluent API; calls `base.OnModelCreating(modelBuilder)` before applying configurations.

## 6. Connections
- Uses domain entities from `Library.Domain.Entities`: `Book`, `BookCategory`, `Staff`, `Customer`.
- Integrates with EF Core (`Microsoft.EntityFrameworkCore`) for ORM capabilities and database interactions.## 1. Overview
Provides a DI registration entry point for the infrastructure layer of a Library application. It wires up the Entity Framework Core `DbContext` and repository implementations, enabling the API/application layers to resolve infrastructure services via dependency injection.

## 2. Type Info
- Type: `static class`
- Inherits: None
- Implements: None
- Namespace: `Library.Infrastructure`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| AddInfrastructure | `public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)` | Registers EF Core `LibraryDbContext` using SQL Server and maps repository interfaces to their concrete implementations; returns the modified service collection. |

## 5. Key Behaviors & Business Rules
- Configures `LibraryDbContext` with SQL Server via `options.UseSqlServer(...)`, using the connection string named `"DefaultConnection"` from `IConfiguration`.
- Registers repositories with scoped lifetime:
  - `IBookRepository` → `BookRepository`
  - `IBookCategoryRepository` → `BookCategoryRepository`
  - `IStaffRepository` → `StaffRepository`
  - `ICustomerRepository` → `CustomerRepository`
- Returns the same `IServiceCollection` instance to support fluent registration.
- No explicit validation or exception handling; relies on EF Core and configuration to be correctly set up.

## 6. Connections
- Downstream:
  - `Library.Infrastructure.Data.LibraryDbContext` (EF Core DbContext)
  - `Library.Infrastructure.Repositories.BookRepository`
  - `Library.Infrastructure.Repositories.BookCategoryRepository`
  - `Library.Infrastructure.Repositories.StaffRepository`
  - `Library.Infrastructure.Repositories.CustomerRepository`
- Upstream:
  - Intended to be invoked from application startup or composition root where `IServiceCollection` and `IConfiguration` are available.# Overview
`BookCategoryRepository` provides CRUD and query operations for `BookCategory` entities using Entity Framework Core. It lives in the infrastructure layer as the concrete repository implementation backing the domain interface, enabling data access to the library database.

# Type Info
- Type: `class`
- Inherits: —
- Implements: `Library.Domain.Interfaces.IBookCategoryRepository`
- Namespace: `Library.Infrastructure.Repositories`

# Dependencies
- `Library.Infrastructure.Data.LibraryDbContext` — EF Core database context used to query and persist `BookCategory` entities.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<BookCategory?> GetByIdAsync(Guid id)` | Retrieves a category by primary key using `FindAsync`; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<BookCategory>> GetAllAsync()` | Returns all categories as a list. |
| GetByNameAsync | `Task<BookCategory?> GetByNameAsync(string name)` | Retrieves the first category matching the provided name or null if none. |
| GetWithBooksAsync | `Task<BookCategory?> GetWithBooksAsync(Guid id)` | Loads a category by id with its `Books` navigation property eagerly included. |
| AddAsync | `Task AddAsync(BookCategory entity)` | Adds a new category and saves changes. |
| UpdateAsync | `Task UpdateAsync(BookCategory entity)` | Updates an existing category and saves changes. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a category by id if it exists and saves changes. |

# Key Behaviors & Business Rules
- Uses EF Core async operations (`FindAsync`, `ToListAsync`, `FirstOrDefaultAsync`, `Include`) for non-blocking I/O.
- Eager loads related `Books` only in `GetWithBooksAsync`; other queries do not include navigation properties.
- Mutating operations (`AddAsync`, `UpdateAsync`, `DeleteAsync`) call `SaveChangesAsync` immediately (no batching/transactions shown).
- `DeleteAsync` is idempotent-like: no action if the entity isn’t found (no exception thrown).
- No input validation or domain rule enforcement within the repository.
- No explicit exception handling; any data access exceptions will propagate to callers.

# Connections
- Downstream: `Library.Infrastructure.Data.LibraryDbContext` and its `DbSet<BookCategory>`; EF Core (`Microsoft.EntityFrameworkCore`) APIs such as `Include`, `FirstOrDefaultAsync`, `ToListAsync`.
- Domain types: `Library.Domain.Entities.BookCategory`, `Library.Domain.Interfaces.IBookCategoryRepository`.
- Upstream callers are not shown; this class is intended to be used wherever `IBookCategoryRepository` is injected.## 1. Overview
`BookRepository` provides data access operations for `Book` entities using Entity Framework Core. It implements the `IBookRepository` interface, encapsulating CRUD and query logic for the infrastructure layer. This repository is intended to be consumed by higher layers (e.g., application/services) via the interface to persist and retrieve domain data.

## 2. Type Info
- Type: `class`
- Inherits: `object`
- Implements: `Library.Domain.Interfaces.IBookRepository`
- Namespace: `Library.Infrastructure.Repositories`

## 3. Dependencies
- `Library.Infrastructure.Data.LibraryDbContext` — EF Core DbContext used to query and persist `Book` entities.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Constructor | `BookRepository(LibraryDbContext context)` | Initializes the repository with a DbContext instance. |
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Retrieves a book by its identifier; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Returns all books. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Returns books where `IsAvailable` is true. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Retrieves a book by exact ISBN match; returns null if not found. |
| AddAsync | `Task AddAsync(Book entity)` | Adds a new book and saves changes. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Updates an existing book and saves changes. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a book by id if it exists and saves changes. |

## 5. Key Behaviors & Business Rules
- Uses EF Core async operations (`FindAsync`, `ToListAsync`, `FirstOrDefaultAsync`) for I/O.
- `AddAsync`, `UpdateAsync`, and `DeleteAsync` call `_context.SaveChangesAsync()` to persist changes immediately.
- `DeleteAsync` safely no-ops if the book is not found (no exception thrown).
- `GetByIdAsync` uses `FindAsync`, leveraging EF Core tracking/identity resolution when applicable.
- No explicit input validation, exception handling, transactions, or caching within this class.

## 6. Connections
- Downstream: `Library.Infrastructure.Data.LibraryDbContext` (`_context.Books` DbSet), EF Core (`Microsoft.EntityFrameworkCore`).
- Domain models: `Library.Domain.Entities.Book`.
- Contracts: `Library.Domain.Interfaces.IBookRepository` (defines the repository contract implemented here).## 1. Overview
`CustomerRepository` provides data access operations for `Customer` entities using Entity Framework Core. It implements the repository pattern for the infrastructure layer, bridging domain interfaces with the database via `LibraryDbContext`.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `Library.Domain.Interfaces.ICustomerRepository`
- Namespace: `Library.Infrastructure.Repositories`

## 3. Dependencies
- `Library.Infrastructure.Data.LibraryDbContext` — EF Core DbContext used to query and persist `Customer` entities.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<Customer?> GetByIdAsync(Guid id)` | Fetches a customer by primary key; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<Customer>> GetAllAsync()` | Retrieves all customers. |
| GetByEmailAsync | `Task<Customer?> GetByEmailAsync(string email)` | Fetches the first customer matching the given email; returns null if none. |
| GetByMembershipNumberAsync | `Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)` | Fetches the first customer matching the given membership number; returns null if none. |
| GetActiveCustomersAsync | `Task<IEnumerable<Customer>> GetActiveCustomersAsync()` | Retrieves customers where `IsActive` is true. |
| AddAsync | `Task AddAsync(Customer entity)` | Adds a new customer and saves changes. |
| UpdateAsync | `Task UpdateAsync(Customer entity)` | Updates an existing customer and saves changes. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Removes a customer by id if it exists and saves changes. |

## 5. Key Behaviors & Business Rules
- Uses EF Core async APIs (`FindAsync`, `FirstOrDefaultAsync`, `ToListAsync`) to avoid blocking.
- Write operations (`AddAsync`, `UpdateAsync`, `DeleteAsync`) call `_context.SaveChangesAsync()` immediately, committing per method call.
- `DeleteAsync` performs a null check after `FindAsync`; if not found, it exits without changes or exception.
- Queries are tracked by default (no `AsNoTracking` used).
- Filtering logic: `GetActiveCustomersAsync` returns only entities with `IsActive == true`.

## 6. Connections
- Downstream: `Library.Infrastructure.Data.LibraryDbContext` (EF Core), `DbSet<Customer>` for persistence.
- Domain types: `Library.Domain.Entities.Customer`.
- Contracts: Implements `Library.Domain.Interfaces.ICustomerRepository` for consumption by higher layers through the domain interface.## 1. Overview
`InMemoryBookRepository` is an infrastructure-layer repository that provides an in-memory implementation of `IBookRepository` for `Book` entities. It supports basic CRUD and query operations without any external persistence, making it suitable for development, testing, or simple runtime scenarios where persistence is not required.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `IBookRepository`
- Namespace: `Library.Infrastructure.Repositories`

## 3. Dependencies
No external dependencies.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<Book?> GetByIdAsync(Guid id)` | Retrieves a book by its `Id`; returns `null` if not found. |
| GetAllAsync | `Task<IEnumerable<Book>> GetAllAsync()` | Returns all books currently in memory. |
| GetAvailableBooksAsync | `Task<IEnumerable<Book>> GetAvailableBooksAsync()` | Returns books where `IsAvailable` is true. |
| GetByISBNAsync | `Task<Book?> GetByISBNAsync(string isbn)` | Retrieves a book by exact `ISBN`; returns `null` if not found. |
| AddAsync | `Task AddAsync(Book entity)` | Adds the provided `Book` to the in-memory collection. |
| UpdateAsync | `Task UpdateAsync(Book entity)` | Replaces an existing book with the same `Id`; no-op if not found. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Removes the book matching the `Id`; no-op if not found. |

## 5. Key Behaviors & Business Rules
- Stores data in a private in-memory `List<Book>`; no persistence or I/O.
- Query methods use LINQ for filtering and selection.
- Returns completed tasks via `Task.FromResult`/`Task.CompletedTask`; no asynchronous I/O.
- Not found cases return `null` (for getters) or perform no operation (for update/delete); no exceptions thrown.
- `UpdateAsync` replaces the entire entity at the found index; does nothing if the `Id` is not present.
- `DeleteAsync` removes the first match by `Id`; does nothing if absent.
- No input validation, concurrency control, or thread safety guarantees.
- No cancellation tokens, logging, caching, or retries.

## 6. Connections
- Upstream: Expected to be called by components depending on `IBookRepository` (e.g., application services); exact callers not shown.
- Downstream: Interacts with `Library.Domain.Entities.Book` and conforms to `Library.Domain.Interfaces.IBookRepository`. No external systems or databases.## 1. Overview
`StaffRepository` provides data access operations for `Staff` entities using Entity Framework Core. It implements the repository pattern to abstract persistence concerns from domain logic. This class resides in the infrastructure layer, backing the domain’s `IStaffRepository` with EF Core queries and commands.

## 2. Type Info
- Type: `class`
- Inherits: None
- Implements: `Library.Domain.Interfaces.IStaffRepository`
- Namespace: `Library.Infrastructure.Repositories`

## 3. Dependencies
- `Library.Infrastructure.Data.LibraryDbContext` — EF Core database context used to query and persist `Staff` entities.

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetByIdAsync | `Task<Library.Domain.Entities.Staff?> GetByIdAsync(Guid id)` | Retrieves a staff member by primary key using `FindAsync`; returns null if not found. |
| GetAllAsync | `Task<IEnumerable<Library.Domain.Entities.Staff>> GetAllAsync()` | Returns all staff records. |
| GetByEmailAsync | `Task<Library.Domain.Entities.Staff?> GetByEmailAsync(string email)` | Returns the first staff member matching the provided email; null if none. |
| GetActiveStaffAsync | `Task<IEnumerable<Library.Domain.Entities.Staff>> GetActiveStaffAsync()` | Returns staff members where `IsActive` is true. |
| AddAsync | `Task AddAsync(Library.Domain.Entities.Staff entity)` | Adds a new staff entity and persists changes. |
| UpdateAsync | `Task UpdateAsync(Library.Domain.Entities.Staff entity)` | Updates an existing staff entity and persists changes. |
| DeleteAsync | `Task DeleteAsync(Guid id)` | Deletes a staff entity by id if it exists and persists changes. |

## 5. Key Behaviors & Business Rules
- Uses EF Core async APIs (`FindAsync`, `FirstOrDefaultAsync`, `ToListAsync`) for non-blocking I/O.
- Persists changes immediately on write operations via `_context.SaveChangesAsync()` in `AddAsync`, `UpdateAsync`, and `DeleteAsync`.
- `DeleteAsync` safely no-ops if the target entity is not found (null-check before removal).
- `GetActiveStaffAsync` filters by the `IsActive` flag.
- No explicit validation, transactions, concurrency handling, or includes for related data.
- Read methods may return `null` when no match is found.

## 6. Connections
- Upstream: Consumed by components depending on `IStaffRepository` (e.g., application services in the domain/application layers).
- Downstream: Interacts with `LibraryDbContext` and its `Staff` `DbSet`, the database via EF Core.
- Domain models: `Library.Domain.Entities.Staff`.
- Interface contract: `Library.Domain.Interfaces.IStaffRepository`.## 1. Overview
`BookCategoriesController` is an ASP.NET Core API controller that exposes read-only endpoints for managing book category data. It delegates data retrieval to the application-layer service `IBookCategoryService` and returns standardized HTTP responses. This controller sits in the API layer, acting as a thin transport boundary over the application services.

## 2. Type Info
- Type: `class`
- Inherits: `ControllerBase`
- Implements: None
- Namespace: `Library.Controllers`

## 3. Dependencies
- `IBookCategoryService` — Application service used to fetch book category data (`GetAllAsync`, `GetByIdAsync`).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| Constructor | `BookCategoriesController(IBookCategoryService categoryService)` | Injects the category service dependency. |
| GetAll | `Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()` | Returns all book categories with HTTP 200 (OK). |
| GetById | `Task<ActionResult<BookCategoryDto>> GetById(Guid id)` | Returns a category by ID with HTTP 200 (OK) or HTTP 404 (NotFound) if absent. |

## 5. Key Behaviors & Business Rules
- Routes:
  - `[ApiController]` and `[Route("api/[controller]")]` enable conventional API behaviors and route to `api/BookCategories`.
  - `[HttpGet]` maps to `GET /api/BookCategories`.
  - `[HttpGet("{id:guid}")]` maps to `GET /api/BookCategories/{id}` with a GUID route constraint.
- Asynchronous I/O via `Task` and service methods (`GetAllAsync`, `GetByIdAsync`).
- Null-check on service result in `GetById`; returns `NotFound()` when no category exists.
- Uses standardized action results: `Ok(...)` for successful responses, `NotFound()` for missing resources.
- No input model binding or validation beyond the GUID route constraint.
- No authorization, caching, or error handling is implemented in this controller.

## 6. Connections
- Downstream: `Library.Application.Interfaces.IBookCategoryService` (application layer), `Library.Application.DTOs.BookCategoryDto`.
- Framework: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`) for routing and action results.
- Upstream callers: HTTP clients invoking `GET /api/BookCategories` and `GET /api/BookCategories/{id}`.# Overview
`BooksController` exposes RESTful endpoints for managing books in a library system. It acts as the API layer, delegating all business operations to an application service (`IBookService`) and transforming service results into HTTP responses.

# Type Info
- Type: `class`
- Inherits: `ControllerBase`
- Implements: None
- Namespace: `Library.Controllers`

# Dependencies
- `IBookService` — application service handling book retrieval, creation, update, and deletion.

# Public API

| Method / Property | Signature | Description |
|---|---|---|
| Constructor | `BooksController(IBookService bookService)` | Injects the book service dependency. |
| GetAll | `Task<ActionResult<IEnumerable<BookDto>>> GetAll()` | GET api/books — returns all books with 200 OK. |
| GetById | `Task<ActionResult<BookDto>> GetById(Guid id)` | GET api/books/{id} — returns a book by ID; 404 if not found. |
| GetAvailable | `Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()` | GET api/books/available — returns available books with 200 OK. |
| Create | `Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)` | POST api/books — creates a book; returns 201 Created with Location header. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)` | PUT api/books/{id} — updates a book; 204 No Content or 404 if not found. |
| Delete | `Task<IActionResult> Delete(Guid id)` | DELETE api/books/{id} — deletes a book; returns 204 No Content. |

# Key Behaviors & Business Rules
- Uses `[ApiController]` and `[Route("api/[controller]")]` for API conventions and routing.
- `GetById` returns `NotFound()` when the service returns `null`.
- `Create` returns `CreatedAtAction(nameof(GetById), new { id = book.Id }, book)` to include a Location header pointing to the new resource.
- `Update` wraps service call in a try/catch; maps `KeyNotFoundException` from the service to HTTP 404.
- `Delete` always returns 204 No Content after invoking the service.
- All endpoints are asynchronous and delegate operations to `IBookService` methods (`GetAllAsync`, `GetByIdAsync`, `GetAvailableBooksAsync`, `CreateAsync`, `UpdateAsync`, `DeleteAsync`).

# Connections
- Downstream: `IBookService` in `Library.Application.Interfaces` with DTOs from `Library.Application.DTOs` (`BookDto`, `CreateBookDto`, `UpdateBookDto`).
- Upstream: HTTP clients calling the API endpoints.
- Framework: ASP.NET Core MVC (`Microsoft.AspNetCore.Mvc`) for routing, model binding, and result generation.## 1. Overview
`CustomersController` exposes HTTP endpoints for managing customers in the API layer of the application. It delegates business operations to an `ICustomerService`, handling request routing, response shaping, and standard HTTP status codes. It fits within ASP.NET Core MVC as a RESTful controller under the route `api/customers`.

## 2. Type Info
- Type: `class`
- Inherits: `ControllerBase`
- Implements: None
- Namespace: `Library.Controllers`

## 3. Dependencies
- `ICustomerService` — Provides customer-related operations (query, create, update, delete).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetAll | `Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()` | Returns all customers with 200 OK. Route: `GET api/customers`. |
| GetById | `Task<ActionResult<CustomerDto>> GetById(Guid id)` | Returns a customer by ID; 200 OK or 404 Not Found if absent. Route: `GET api/customers/{id}`. |
| GetActive | `Task<ActionResult<IEnumerable<CustomerDto>>> GetActive()` | Returns active customers with 200 OK. Route: `GET api/customers/active`. |
| Create | `Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto createDto)` | Creates a customer; returns 201 Created with Location header to `GetById`. Route: `POST api/customers`. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto updateDto)` | Updates a customer; 204 No Content on success, 404 Not Found if the ID does not exist. Route: `PUT api/customers/{id}`. |
| Delete | `Task<IActionResult> Delete(Guid id)` | Deletes a customer; returns 204 No Content. Route: `DELETE api/customers/{id}`. |

## 5. Key Behaviors & Business Rules
- Uses `ICustomerService` for all operations; controller remains thin with no business logic.
- Returns standardized HTTP responses:
  - 200 OK for successful reads.
  - 201 Created with `CreatedAtAction` on creation, including `{ id = customer.Id }`.
  - 204 No Content for successful updates and deletes.
  - 404 Not Found when `GetById` yields null or when `Update` catches `KeyNotFoundException`.
- Exception handling: `Update` translates `KeyNotFoundException` from the service into 404.
- Routing and constraints:
  - Base route: `api/[controller]` → `api/customers`.
  - `{id:guid}` ensures GUID parsing for ID routes.

## 6. Connections
- Downstream: `Library.Application.Interfaces.ICustomerService` and DTOs from `Library.Application.DTOs` (`CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`).
- Upstream: HTTP clients consuming the REST API (e.g., frontend or external integrations) via ASP.NET Core MVC.## 1. Overview
`StaffController` is an ASP.NET Core API controller that exposes CRUD endpoints for managing staff resources. It serves as the API layer entry point, delegating all business operations to an `IStaffService` and shaping HTTP responses (status codes and payloads).

## 2. Type Info
- Type: `class`
- Inherits: `Microsoft.AspNetCore.Mvc.ControllerBase`
- Implements: None
- Namespace: `Library.Controllers`

## 3. Dependencies
- `IStaffService` — orchestrates staff-related operations (retrieval, creation, update, deletion).

## 4. Public API

| Method / Property | Signature | Description |
|---|---|---|
| GetAll | `Task<ActionResult<IEnumerable<StaffDto>>> GetAll()` | Returns all staff as `200 OK`. |
| GetById | `Task<ActionResult<StaffDto>> GetById(Guid id)` | Returns a staff member by ID; `404 Not Found` if absent, else `200 OK`. |
| GetActive | `Task<ActionResult<IEnumerable<StaffDto>>> GetActive()` | Returns active staff as `200 OK`. |
| Create | `Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)` | Creates a staff member; responds `201 Created` with Location header via `CreatedAtAction`. |
| Update | `Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)` | Updates a staff member; `204 No Content` on success; `404 Not Found` if not found (via caught `KeyNotFoundException`). |
| Delete | `Task<IActionResult> Delete(Guid id)` | Deletes a staff member; returns `204 No Content`. |

## 5. Key Behaviors & Business Rules
- Uses async service calls for all operations.
- HTTP status mapping:
  - `GetById`: returns `404 Not Found` if service returns `null`.
  - `Create`: uses `CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff)` to set Location and payload.
  - `Update`: catches `KeyNotFoundException` from service to return `404 Not Found`; otherwise `204 No Content`.
  - `Delete`: always returns `204 No Content` (assumes service handles missing IDs or throws outside captured scope).
- Model binding via `[FromBody]` for create/update DTOs; no explicit validation logic in controller.
- Route configuration:
  - Base route: `api/[controller]` → `api/staff`.
  - Specific routes: `GET api/staff`, `GET api/staff/{id:guid}`, `GET api/staff/active`, `POST api/staff`, `PUT api/staff/{id:guid}`, `DELETE api/staff/{id:guid}`.

## 6. Connections
- Downstream: `IStaffService` (`GetAllAsync`, `GetByIdAsync`, `GetActiveStaffAsync`, `CreateAsync`, `UpdateAsync`, `DeleteAsync`) from `Library.Application.Interfaces`.
- Data contracts: `StaffDto`, `CreateStaffDto`, `UpdateStaffDto` from `Library.Application.DTOs`.
- Upstream: HTTP clients consuming the REST API endpoints.# Overview
Entry point for the ASP.NET Core web application using top-level statements. It wires up dependency injection, configures middleware, and exposes controller-based HTTP endpoints. This file sits in the API layer (hosting layer) and composes the application and infrastructure modules.

# Type Info
- Type: Top-level statements (implicit `Program`)
- Inherits: None
- Implements: None
- Namespace: None (file-scoped, top-level)

# Dependencies
- No external dependencies.

# Public API
No public or protected members are declared; this file uses top-level statements to bootstrap the application.

# Key Behaviors & Business Rules
- Registers DI modules:
  - `AddApplication()` from `Library.Application` to register application-layer services.
  - `AddInfrastructure(builder.Configuration)` from `Library.Infrastructure` to register infrastructure services using configuration.
- Adds MVC controllers via `AddControllers()`.
- Enables API discovery and Swagger generation with `AddEndpointsApiExplorer()` and `AddSwaggerGen()`.
- Builds the app and configures middleware pipeline:
  - In Development: enables `UseSwagger()` and `UseSwaggerUI()` for interactive API docs.
  - Enforces HTTPS with `UseHttpsRedirection()`.
  - Enables authorization middleware via `UseAuthorization()` (authentication is not configured here).
- Maps controller routes with `MapControllers()`.
- Starts the host with `app.Run()`.

# Connections
- Downstream:
  - `Library.Application` via `AddApplication()` (application-layer services).
  - `Library.Infrastructure` via `AddInfrastructure(builder.Configuration)` (infrastructure services, e.g., persistence, integrations).
  - ASP.NET Core middleware: HTTPS redirection, authorization, Swagger.
  - MVC controllers discovered and mapped by `MapControllers()`.
- Upstream:
  - Launched by the .NET runtime as the application entry point.