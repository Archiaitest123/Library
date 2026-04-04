# Environment Matrix

## Environments

| Property | Development | Test | Production |
|---|---|---|---|
| **URL** | `https://localhost:5001` | `https://library-api-test.example.com` | `https://library-api.example.com` |
| **Database** | LocalDB / SQL Express | SQL Server (Test) | SQL Server (Prod) |
| **DB Name** | `LibraryDb` | `LibraryDb_Test` | `LibraryDb_Prod` |
| **Swagger** | ✅ Enabled | ✅ Enabled | ❌ Disabled |
| **HTTPS** | Self-signed cert | Managed cert | Managed cert |
| **Logging** | Debug + Console | Information + File | Warning + Structured |
| **Email** | Local SMTP / MailHog | Test SMTP | Production SMTP |

## Configuration Files

| Environment | Config File |
|---|---|
| Base | `appsettings.json` |
| Development | `appsettings.Development.json` |
| Test | `appsettings.Test.json` |
| Production | `appsettings.Production.json` |

The environment is determined by the `ASPNETCORE_ENVIRONMENT` environment variable.

## Environment Variables

| Variable | Description | Example |
|---|---|---|
| `ASPNETCORE_ENVIRONMENT` | Active environment name | `Development`, `Test`, `Production` |
| `ConnectionStrings__DefaultConnection` | Database connection string | `Server=...;Database=LibraryDb;...` |
| `Email__Host` | SMTP server host | `smtp.example.com` |
| `Email__Port` | SMTP port | `587` |
| `Email__Username` | SMTP username | `noreply@example.com` |
| `Email__Password` | SMTP password | (secret) |
| `Email__From` | Sender email address | `noreply@example.com` |
| `Email__NotificationTo` | Notification recipient | `admin@example.com` |
| `Email__EnableSsl` | Enable SSL for SMTP | `true` |

## Resource Requirements

| Resource | Development | Test | Production |
|---|---|---|---|
| CPU | 1 core | 2 cores | 4 cores |
| RAM | 512 MB | 1 GB | 2 GB |
| Disk (App) | 100 MB | 100 MB | 500 MB |
| Disk (DB) | 1 GB | 5 GB | 50 GB |
