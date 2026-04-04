# Backup & Restore Procedures

## Database Backup

### Manual Backup (SQL Server)

```sql
BACKUP DATABASE [LibraryDb]
TO DISK = 'C:\Backups\LibraryDb_20240115.bak'
WITH FORMAT, COMPRESSION, STATS = 10;
```

### PowerShell Backup Script

```powershell
$serverInstance = "(localdb)\mssqllocaldb"
$database = "LibraryDb"
$backupPath = "C:\Backups"
$timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
$backupFile = "$backupPath\${database}_${timestamp}.bak"

Invoke-Sqlcmd -ServerInstance $serverInstance -Query @"
BACKUP DATABASE [$database]
TO DISK = '$backupFile'
WITH FORMAT, COMPRESSION, STATS = 10;
"@

Write-Host "Backup completed: $backupFile"
```

### Scheduled Backup

Configure a SQL Server Agent job or Windows Task Scheduler to run the backup script daily.

Recommended schedule:
| Backup Type | Frequency | Retention |
|---|---|---|
| Full | Daily at 02:00 | 30 days |
| Differential | Every 6 hours | 7 days |
| Transaction Log | Every 15 minutes | 3 days |

## Database Restore

### Full Restore

```sql
USE [master];
ALTER DATABASE [LibraryDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE [LibraryDb]
FROM DISK = 'C:\Backups\LibraryDb_20240115.bak'
WITH REPLACE, RECOVERY;

ALTER DATABASE [LibraryDb] SET MULTI_USER;
```

### Point-in-Time Restore

```sql
RESTORE DATABASE [LibraryDb]
FROM DISK = 'C:\Backups\LibraryDb_Full.bak'
WITH NORECOVERY;

RESTORE LOG [LibraryDb]
FROM DISK = 'C:\Backups\LibraryDb_Log.trn'
WITH STOPAT = '2024-01-15T14:30:00', RECOVERY;
```

## Application Configuration Backup

Back up the following configuration files:

| File | Location | Contains |
|---|---|---|
| `appsettings.json` | `Library/` | Base configuration |
| `appsettings.Production.json` | `Library/` | Production overrides |
| Environment variables | Server | Secrets, connection strings |

### Export Environment Variables (Windows)

```powershell
Get-ChildItem Env: | Where-Object { $_.Name -like "ConnectionStrings*" -or $_.Name -like "Email*" } |
    Export-Csv -Path "C:\Backups\env_vars_backup.csv" -NoTypeInformation
```

## Disaster Recovery Checklist

1. ✅ Restore SQL Server database from latest backup
2. ✅ Verify application configuration files
3. ✅ Set environment variables (connection strings, email settings)
4. ✅ Apply any pending EF Core migrations:
   ```bash
   dotnet ef database update --project Library.Infrastructure --startup-project Library
   ```
5. ✅ Start the application and verify health
6. ✅ Test critical endpoints via Swagger
7. ✅ Verify email connectivity
8. ✅ Notify stakeholders of recovery completion
