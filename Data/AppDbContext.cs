using Microsoft.EntityFrameworkCore;
using Test2Retake.Entities;

namespace Test2Retake.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<RentalExtra> RentalExtras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RentalExtra>()
            .HasKey(r => new { r.RentalId, r.ExtraId });
    }
}

// dotnet ef migrations add InitialCreate --output-dir Migrations
// dotnet ef database update