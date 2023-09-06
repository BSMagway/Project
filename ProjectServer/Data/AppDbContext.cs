
using ProjectServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Costumer> Costumers { get; set; }
    public DbSet<Dimension> Dimendions { get; set; }
    public DbSet<MoistureSoilTest> MoistureSoilTests { get; set; }
}

