using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookCategory> BookCategories => Set<BookCategory>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<BookLoan> BookLoans => Set<BookLoan>();
    public DbSet<BookReservation> BookReservations => Set<BookReservation>();
    public DbSet<Fine> Fines => Set<Fine>();
    public DbSet<LibraryBranch> LibraryBranches => Set<LibraryBranch>();
    public DbSet<BookReview> BookReviews => Set<BookReview>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global query filter for soft delete
        modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookCategory>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Publisher>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Customer>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookLoan>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookReservation>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Fine>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<LibraryBranch>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<BookReview>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Notification>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);

        // Author
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Biography).HasMaxLength(2000);
            entity.Property(a => a.Nationality).HasMaxLength(100);
            entity.Property(a => a.Website).HasMaxLength(500);
        });

        // Publisher
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Address).HasMaxLength(500);
            entity.Property(p => p.City).HasMaxLength(100);
            entity.Property(p => p.Country).HasMaxLength(100);
            entity.Property(p => p.Phone).HasMaxLength(20);
            entity.Property(p => p.Email).HasMaxLength(200);
            entity.Property(p => p.Website).HasMaxLength(500);
            entity.HasIndex(p => p.Name);
        });

        // Book
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title).IsRequired().HasMaxLength(300);
            entity.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
            entity.Property(b => b.Description).HasMaxLength(2000);
            entity.Property(b => b.Language).HasMaxLength(50);
            entity.Property(b => b.CoverImageUrl).HasMaxLength(1000);
            entity.Property(b => b.Price).HasPrecision(10, 2);
            entity.HasIndex(b => b.ISBN).IsUnique();
            entity.HasIndex(b => b.Title);

            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(b => b.BookCategory)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.BookCategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(b => b.LibraryBranch)
                .WithMany(lb => lb.Books)
                .HasForeignKey(b => b.LibraryBranchId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // BookCategory
        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Description).HasMaxLength(500);
            entity.Property(c => c.IconUrl).HasMaxLength(500);
            entity.HasIndex(c => c.Name).IsUnique();

            entity.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Phone).HasMaxLength(20);
            entity.Property(c => c.Address).HasMaxLength(500);
            entity.Property(c => c.City).HasMaxLength(100);
            entity.Property(c => c.PostalCode).HasMaxLength(20);
            entity.Property(c => c.MembershipNumber).IsRequired().HasMaxLength(50);
            entity.Property(c => c.ProfileImageUrl).HasMaxLength(1000);
            entity.HasIndex(c => c.Email).IsUnique();
            entity.HasIndex(c => c.MembershipNumber).IsUnique();
        });

        // BookLoan
        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Notes).HasMaxLength(1000);
            entity.HasIndex(l => l.Status);
            entity.HasIndex(l => l.DueDate);

            entity.HasOne(l => l.Book)
                .WithMany(b => b.BookLoans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(l => l.Customer)
                .WithMany(c => c.BookLoans)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(l => l.ProcessedByUser)
                .WithMany(u => u.ProcessedLoans)
                .HasForeignKey(l => l.ProcessedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // BookReservation
        modelBuilder.Entity<BookReservation>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Notes).HasMaxLength(1000);
            entity.HasIndex(r => r.Status);

            entity.HasOne(r => r.Book)
                .WithMany(b => b.BookReservations)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Customer)
                .WithMany(c => c.BookReservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Fine
        modelBuilder.Entity<Fine>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Amount).HasPrecision(10, 2);
            entity.Property(f => f.Reason).IsRequired().HasMaxLength(500);
            entity.Property(f => f.PaymentMethod).HasMaxLength(50);
            entity.HasIndex(f => f.Status);

            entity.HasOne(f => f.BookLoan)
                .WithMany(l => l.Fines)
                .HasForeignKey(f => f.BookLoanId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(f => f.Customer)
                .WithMany(c => c.Fines)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // LibraryBranch
        modelBuilder.Entity<LibraryBranch>(entity =>
        {
            entity.HasKey(lb => lb.Id);
            entity.Property(lb => lb.Name).IsRequired().HasMaxLength(200);
            entity.Property(lb => lb.Address).IsRequired().HasMaxLength(500);
            entity.Property(lb => lb.City).IsRequired().HasMaxLength(100);
            entity.Property(lb => lb.PostalCode).HasMaxLength(20);
            entity.Property(lb => lb.Phone).IsRequired().HasMaxLength(20);
            entity.Property(lb => lb.Email).HasMaxLength(200);
            entity.Property(lb => lb.Description).HasMaxLength(1000);
            entity.HasIndex(lb => lb.Name).IsUnique();
        });

        // BookReview
        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Title).HasMaxLength(200);
            entity.Property(r => r.Comment).HasMaxLength(2000);

            entity.HasOne(r => r.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Customer)
                .WithMany(c => c.BookReviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(r => new { r.BookId, r.CustomerId }).IsUnique();
        });

        // Notification
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Title).IsRequired().HasMaxLength(200);
            entity.Property(n => n.Message).IsRequired().HasMaxLength(2000);
            entity.HasIndex(n => new { n.CustomerId, n.IsRead });

            entity.HasOne(n => n.Customer)
                .WithMany(c => c.Notifications)
                .HasForeignKey(n => n.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(500);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Phone).HasMaxLength(20);
            entity.Property(u => u.Position).HasMaxLength(100);
            entity.Property(u => u.EmployeeNumber).HasMaxLength(20);
            entity.Property(u => u.Salary).HasPrecision(10, 2);
            entity.Property(u => u.RefreshToken).HasMaxLength(500);
            entity.HasIndex(u => u.Username).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.EmployeeNumber).IsUnique().HasFilter("[EmployeeNumber] IS NOT NULL");

            entity.HasOne(u => u.LibraryBranch)
                .WithMany(lb => lb.Users)
                .HasForeignKey(u => u.LibraryBranchId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // AuditLog
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.EntityName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Action).IsRequired().HasMaxLength(50);
            entity.Property(a => a.UserId).HasMaxLength(100);
            entity.Property(a => a.UserName).HasMaxLength(200);
            entity.Property(a => a.IpAddress).HasMaxLength(50);
            entity.HasIndex(a => new { a.EntityName, a.EntityId });
            entity.HasIndex(a => a.Timestamp);
        });
    }
}
