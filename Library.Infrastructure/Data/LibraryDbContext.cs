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
    public DbSet<Staff> Staff => Set<Staff>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasIndex(b => b.ISBN)
                .IsUnique();

            entity.HasOne(b => b.BookCategory)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.BookCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Description)
                .HasMaxLength(500);

            entity.HasIndex(c => c.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(s => s.Phone)
                .HasMaxLength(20);

            entity.Property(s => s.Position)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasIndex(s => s.Email)
                .IsUnique();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.Phone)
                .HasMaxLength(20);

            entity.Property(c => c.Address)
                .HasMaxLength(500);

            entity.Property(c => c.MembershipNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(c => c.Email)
                .IsUnique();

            entity.HasIndex(c => c.MembershipNumber)
                .IsUnique();
        });
    }
}
