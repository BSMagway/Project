using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;

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

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Dimension> Dimensions { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<MoistureSoilTest> MoistureSoilTests { get; set; }
}

