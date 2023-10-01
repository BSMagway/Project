using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Soil;
using System.Reflection.Metadata;

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
        Database.EnsureCreated();
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

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Test> Tests { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<MoistureSoilTest> MoistureSoilTests { get; set; }

    public DbSet<DensitySoilTest> DensitySoilTests { get; set; }
}

