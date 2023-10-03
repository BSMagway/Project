using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Soil;
using System.Reflection.Metadata;

namespace ProjectServer.Data;

/// <summary>
/// Класс контекста базы данных.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Конструктор создания контекста базы данных.
    /// </summary>
    /// <param name="options">Опции создания контекста базы данных.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>().UseTptMappingStrategy();
    }

    /// <summary>
    /// Таблица заказчиков.
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Таблица измерений.
    /// </summary>
    public DbSet<Dimension> Dimensions { get; set; }

    /// <summary>
    /// Таблица с базовой информацией тестов.
    /// </summary>
    public DbSet<Test> Tests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению влажности грунта.
    /// </summary>
    public DbSet<MoistureSoilTest> MoistureSoilTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению плотности грунта.
    /// </summary>
    public DbSet<DensitySoilTest> DensitySoilTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению границы текучести грунта.
    /// </summary>
    public DbSet<YieldLimitSoilTest> YieldLimitSoilTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению границы раскатывания грунта.
    /// </summary>
    public DbSet<RollingBoundarySoilTest> RollingBoundarySoilTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению влажности щебня.
    /// </summary>
    public DbSet<MoistureGravelTest> MoistureGravelTests { get; set; }
}

