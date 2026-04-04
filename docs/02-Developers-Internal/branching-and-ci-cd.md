# Branching & CI/CD Strategy

## Branching Model

The project uses a simplified Git branching strategy:

```
master (main)
  │
  ├── feature/xxx    ← new feature development
  ├── bugfix/xxx     ← bug fixes
  └── release/x.x    ← release preparation
```

### Branch Naming Convention

| Branch Type | Pattern | Example |
|---|---|---|
| Feature | `feature/<short-description>` | `feature/add-loan-management` |
| Bug Fix | `bugfix/<short-description>` | `bugfix/fix-book-isbn-validation` |
| Release | `release/<version>` | `release/1.0` |
| Hotfix | `hotfix/<short-description>` | `hotfix/fix-db-connection` |

### Workflow

1. Create a feature branch from `master`
2. Develop and commit changes
3. Open a Pull Request to `master`
4. Code review + CI checks pass
5. Merge via squash merge
6. Delete the feature branch

## CI/CD Pipeline

### Continuous Integration (CI)

Triggered on every push and pull request to `master`:

1. **Restore** — `dotnet restore`
2. **Build** — `dotnet build --configuration Release`
3. **Test** — `dotnet test --configuration Release`
4. **Publish** — `dotnet publish` (on merge to master)

### Continuous Deployment (CD)

Triggered after successful CI on `master`:

1. **Build Docker image**
2. **Push to container registry**
3. **Deploy to target environment** (dev → test → prod)

### Environment Promotion

```
dev  →  test  →  prod
```

Each environment has its own configuration (connection strings, email settings, etc.) managed through environment-specific `appsettings.{Environment}.json` files.
