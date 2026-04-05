using Library.Application.Interfaces;
using Library.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookCategoryService, BookCategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<ILoanPolicyService, LoanPolicyService>();
        services.AddScoped<IBookLoanService, BookLoanService>();
        services.AddScoped<IBookReservationService, BookReservationService>();
        services.AddScoped<IReservationQueueService, ReservationQueueService>();
        services.AddScoped<IFineService, FineService>();
        services.AddScoped<ILibraryBranchService, LibraryBranchService>();
        services.AddScoped<IBookReviewService, BookReviewService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
