using Microsoft.EntityFrameworkCore;
using ProjectCommon.Models;
using ProjectCommon.Models.Authentication;
using ProjectCommon.Models.Base;
using ProjectCommon.Models.Material.Geotextile;
using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;
using ProjectCommon.Models.Material.SandAndGravel;
using ProjectCommon.Models.Material.Soil;

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
    /// Настройка создаваемой базы данных.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>().UseTptMappingStrategy();
    }

    /// <summary>
    /// Таблица пользователей.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Таблица заказчиков.
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

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

    /// <summary>
    /// Таблица с информацией тестов по определению содержания зерен слабых пород.
    /// </summary>
    public DbSet<WeakGrainsGravelTest> WeakGrainsGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению содержания зерен пластинчатой (лещадной) и игловатой формы.
    /// </summary>
    public DbSet<FlakyGrainsGravelTest> FlakyGrainsGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению содержания пылевидных и глинистых частиц в щебне.
    /// </summary>
    public DbSet<DustGravelTest> DustGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению содержания дробленых зерен в щебне из гравия.
    /// </summary>
    public DbSet<CrushedGrainsGravelTest> CrushedGrainsGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению дробимости щебня.
    /// </summary>
    public DbSet<CrushabilityGravelTest> CrushabilityGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению содержания глины в комках в щебне.
    /// </summary>
    public DbSet<ClayInLumpsGravelTest> ClayInLumpsGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению насыпной плотности щебня.
    /// </summary>
    public DbSet<BulkDensityGravelTest> BulkDensityGravelTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению фильтрации в плоскости геотекстильного полотна.
    /// </summary>
    public DbSet<FiltrationPlaneGeotextileTest> FiltrationPlaneGeotextileTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению насыпной плотности песка.
    /// </summary>
    public DbSet<BulkDensitySandTest> BulkDensitySandTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению содержания пылевидных и глинистых частиц в песке.
    /// </summary>
    public DbSet<DustSandTest> DustSandTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению влажности песка.
    /// </summary>
    public DbSet<MoistureSandTest> MoistureSandTests { get; set; }

    /// <summary>
    /// Таблица с информацией тестов по определению насыпной плотности ПГС.
    /// </summary>
    public DbSet<BulkDensitySandAndGravelTest> BulkDensitySandAndGravelTests { get; set; }

}

