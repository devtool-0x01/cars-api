
using dotnet5api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet5api.Data
{
  public class HyperdriveDbContext : DbContext
  {
    public HyperdriveDbContext() : base()
    {
      Database.EnsureCreated();
    }
    public HyperdriveDbContext(DbContextOptions<HyperdriveDbContext> options) : base(options)
    {
      Database.EnsureCreated();
    }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarAttribute> CarAttributes { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   // base.OnConfiguring(optionsBuilder);
    //   // optionsBuilder.UseSqlite("Data Source=CustomerDB.db;");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Car>().ToTable("Car");
      modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
      modelBuilder.Entity<CarAttribute>().ToTable("CarAttributes");
    }
  }
}