# Runbook: Basic Troubleshooting

## 1. Application Won't Start

### Symptoms
- Process exits immediately
- Port binding error
- Configuration error in logs

### Steps
1. Check the `ASPNETCORE_ENVIRONMENT` variable is set
2. Verify `appsettings.json` exists and is valid JSON
3. Ensure the target port is not in use:
   ```bash
   netstat -ano | findstr :5001
   ```
4. Check .NET SDK version:
   ```bash
   dotnet --version   # Should be 8.x
   ```
5. Review application logs (console output or log files)

---

## 2. Database Connection Failure

### Symptoms
- `SqlException: A network-related or instance-specific error...`
- `Cannot open database "LibraryDb" requested by the login`

### Steps
1. Verify SQL Server is running:
   ```bash
   # Windows
   Get-Service MSSQLSERVER
   # or for LocalDB
   sqllocaldb info
   ```
2. Test the connection string manually:
   ```bash
   sqlcmd -S (localdb)\mssqllocaldb -d LibraryDb -Q "SELECT 1"
   ```
3. Check connection string in `appsettings.json` or environment variables
4. Ensure database migrations have been applied:
   ```bash
   dotnet ef database update --project Library.Infrastructure --startup-project Library
   ```
5. Check firewall rules if connecting to a remote SQL Server

---

## 3. API Returns 500 Internal Server Error

### Symptoms
- All or specific endpoints return HTTP 500

### Steps
1. Check application logs for exception details
2. Enable detailed error responses in Development:
   ```
   ASPNETCORE_ENVIRONMENT=Development
   ```
3. Common causes:
   - Database connection lost
   - Null reference in service layer
   - Missing DI registration
4. Verify DI registrations in `Program.cs`:
   - `builder.Services.AddApplication()`
   - `builder.Services.AddInfrastructure(builder.Configuration)`

---

## 4. Email Notifications Not Sending

### Symptoms
- No emails received
- No errors in API responses (fire-and-forget)

### Steps
1. Verify email configuration in `appsettings.json`:
   ```json
   {
     "Email": {
       "Host": "smtp.example.com",
       "Port": 587,
       "EnableSsl": true
     }
   }
   ```
2. Test SMTP connectivity:
   ```bash
   Test-NetConnection -ComputerName smtp.example.com -Port 587
   ```
3. Check SMTP credentials
4. Review `SmtpEmailService` logs for exceptions

---

## 5. Swagger UI Not Loading

### Symptoms
- `/swagger` returns 404
- Swagger UI shows empty page

### Steps
1. Swagger is only enabled in Development environment:
   ```csharp
   if (app.Environment.IsDevelopment())
   {
       app.UseSwagger();
       app.UseSwaggerUI();
   }
   ```
2. Set `ASPNETCORE_ENVIRONMENT=Development`
3. Verify Swashbuckle package is referenced in `Library.csproj`

---

## 6. Performance Degradation

### Symptoms
- Slow API responses (> 2 seconds)
- High CPU or memory usage

### Steps
1. Check database query performance (slow queries, missing indexes)
2. Monitor connection pool (max pool size, connection leaks)
3. Review EF Core query logging:
   ```json
   {
     "Logging": {
       "LogLevel": {
         "Microsoft.EntityFrameworkCore.Database.Command": "Information"
       }
     }
   }
   ```
4. Check for N+1 query patterns in repositories
5. Monitor memory with `dotnet-counters`:
   ```bash
   dotnet-counters monitor --process-id <PID>
   ```
