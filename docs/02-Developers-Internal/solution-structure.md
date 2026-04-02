# Solution Structure

## Overview

The solution is organized following Clean Architecture with four projects:

```
Library.sln
│
├── Library/                         # Presentation Layer (ASP.NET Core Web API)
│   ├── Controllers/
│   │   ├── BooksController.cs       # Books CRUD endpoints
│   │   ├── BookCategoriesController.cs
│   │   ├── CustomersController.cs
│   │   └── StaffController.cs
│   └── Program.cs                   # Application entry point & DI setup
│
├── Library.Application/             # Application Layer
│   ├── DTOs/
│   │   ├── BookDto.cs / CreateBookDto.cs / UpdateBookDto.cs
│   │   ├── BookCategoryDto.cs / CreateBookCategoryDto.cs / UpdateBookCategoryDto.cs
│   │   ├── CustomerDto.cs / CreateCustomerDto.cs / UpdateCustomerDto.cs
│   │   └── StaffDto.cs / CreateStaffDto.cs / UpdateStaffDto.cs
│   ├── Interfaces/
│   │   ├── IBookService.cs
│   │   ├── IBookCategoryService.cs
│   │   ├── ICustomerService.cs
│   │   ├── IStaffService.cs
│   │   └── IEmailService.cs
│   ├── Mappings/
│   │   ├── BookMappings.cs
│   │   ├── BookCategoryMappings.cs
│   │   ├── CustomerMappings.cs
│   │   └── StaffMappings.cs
│   ├── Services/
│   │   ├── BookService.cs
│   │   ├── BookCategoryService.cs
│   │   ├── CustomerService.cs
│   │   └── StaffService.cs
│   ├── Email/
│   │   └── EmailSettings.cs
│   └── DependencyInjection.cs
│
├── Library.Domain/                  # Domain Layer
│   ├── Entities/
│   │   ├── Book.cs
│   │   ├── BookCategory.cs
│   │   ├── Customer.cs
│   │   └── Staff.cs
│   └── Interfaces/
│       ├── IRepository.cs           # Generic repository interface
│       ├── IBookRepository.cs
│       ├── IBookCategoryRepository.cs
│       ├── ICustomerRepository.cs
│       └── IStaffRepository.cs
│
└── Library.Infrastructure/          # Infrastructure Layer
    ├── Data/
    │   └── LibraryDbContext.cs      # EF Core DbContext with Fluent API
    ├── Repositories/
    │   ├── BookRepository.cs
    │   ├── BookCategoryRepository.cs
    │   ├── CustomerRepository.cs
    │   ├── StaffRepository.cs
    │   └── InMemoryBookRepository.cs
    ├── Email/
    │   └── SmtpEmailService.cs
    └── DependencyInjection.cs
```

## Project Dependencies

```
Library (API) ──► Library.Application ──► Library.Domain
      │                                        ▲
      └──► Library.Infrastructure ─────────────┘
                      │
                      └──► Library.Application
```

## Key Conventions

- **Namespace = Folder path:** e.g., `Library.Domain.Entities`, `Library.Application.DTOs`
- **File-scoped namespaces:** All files use `namespace X.Y.Z;` syntax
- **Dependency Injection:** Each layer has a `DependencyInjection.cs` extension method
- **Nullable reference types:** Enabled across all projects
- **Implicit usings:** Enabled for cleaner code files
