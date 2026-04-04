using Library.Application;
using Library.Infrastructure;
using Library.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management API",
        Version = "v1",
        Description = "Enterprise Library Management System API",
        Contact = new OpenApiContact
        {
            Name = "Library Admin",
            Email = "admin@library.com"
        }
    });
});

// Health Checks
builder.Services.AddHealthChecks();

// Response Caching
builder.Services.AddResponseCaching();

var app = builder.Build();

// Middleware pipeline
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management API v1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
