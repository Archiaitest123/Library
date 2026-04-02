using Library.Application.Email;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Email;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        var emailSettings = new EmailSettings
        {
            Host = configuration["Email:Host"] ?? string.Empty,
            Port = int.TryParse(configuration["Email:Port"], out var port) ? port : 587,
            Username = configuration["Email:Username"] ?? string.Empty,
            Password = configuration["Email:Password"] ?? string.Empty,
            From = configuration["Email:From"] ?? string.Empty,
            NotificationTo = configuration["Email:NotificationTo"] ?? string.Empty,
            EnableSsl = bool.TryParse(configuration["Email:EnableSsl"], out var enableSsl) ? enableSsl : true
        };
        services.AddSingleton(emailSettings);

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmailService, SmtpEmailService>();

        return services;
    }
}
