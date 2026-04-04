# Installation Guide

## Prerequisites

| Software | Minimum Version | Notes |
|---|---|---|
| .NET SDK | 8.0 | [Download](https://dotnet.microsoft.com/download/dotnet/8.0) |
| SQL Server | 2019+ | LocalDB, Express, or full edition |
| Git | 2.x | For cloning the repository |

## Step 1: Clone the Repository

```bash
git clone https://github.com/Archiaitest123/Library.git
cd Library
```

## Step 2: Restore Dependencies

```bash
dotnet restore
```

## Step 3: Configure the Database

Edit `Library/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

For a full SQL Server instance:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=LibraryDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  }
}
```

## Step 4: Apply Database Migrations

```bash
dotnet ef database update --project Library.Infrastructure --startup-project Library
```

If EF tools are not installed:
```bash
dotnet tool install --global dotnet-ef
```

## Step 5: Configure Email (Optional)

Edit `Library/appsettings.json`:

```json
{
  "Email": {
    "Host": "smtp.example.com",
    "Port": 587,
    "Username": "noreply@example.com",
    "Password": "your-smtp-password",
    "From": "noreply@example.com",
    "NotificationTo": "admin@example.com",
    "EnableSsl": true
  }
}
```

## Step 6: Build & Run

```bash
dotnet build
dotnet run --project Library
```

The API will start at:
- `https://localhost:5001`
- `http://localhost:5000`

## Step 7: Verify

Open Swagger UI in a browser:
```
https://localhost:5001/swagger
```

## Docker Deployment

```bash
docker build -f infra/docker/Dockerfile.api -t library-api .
docker run -p 5000:8080 -e ConnectionStrings__DefaultConnection="Server=host.docker.internal;Database=LibraryDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;" library-api
```

## Troubleshooting

| Issue | Solution |
|---|---|
| `dotnet ef` not found | Run `dotnet tool install --global dotnet-ef` |
| DB connection failed | Verify SQL Server is running and connection string is correct |
| Port already in use | Change port in `launchSettings.json` or use `--urls` parameter |
| SSL certificate error | Add `TrustServerCertificate=True` to connection string |
