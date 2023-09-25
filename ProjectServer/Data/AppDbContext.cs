using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;

namespace ProjectServer.Data;

/// <summary>
/// 
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated(); // Лучше использовать подход EF Core Migrations (https://metanit.com/sharp/entityframeworkcore/2.15.php)
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>().UseTptMappingStrategy();
    }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Dimension> Dimensions { get; set; }

    public DbSet<Test> Tests { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<MoistureSoilTest> MoistureSoilTests { get; set; }
}

