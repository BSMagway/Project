using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Geotextile;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Sand;
using ProjectServer.Interfaces.Managers.MaterialTests.SandAndGravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;
using ProjectServer.Interfaces.Service;
using ProjectServer.Managers;
using ProjectServer.Managers.MaterialTests.Geotextile;
using ProjectServer.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Sand;
using ProjectServer.Managers.MaterialTests.SandAndGravel;
using ProjectServer.Managers.MaterialTests.Soil;
using ProjectServer.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7143",
            ValidAudience = "https://localhost:7143",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IMoistureSoilTestManager, MoistureSoilTestManager>();
builder.Services.AddScoped<IDensitySoilTestManager, DensitySoilTestManager>();
builder.Services.AddScoped<IYieldLimitSoilTestManager, YieldLimitSoilTestManager>();
builder.Services.AddScoped<IRollingBoundarySoilTestManager, RollingBoundarySoilTestManager>();

builder.Services.AddScoped<IMoistureGravelTestManager, MoistureGravelTestManager>();
builder.Services.AddScoped<IWeakGrainsGravelTestManager, WeakGrainsGravelTestManager>();
builder.Services.AddScoped<IFlakyGrainsGravelTestManager, FlakyGrainsGravelTestManager>();
builder.Services.AddScoped<IDustGravelTestManager, DustGravelTestManager>();
builder.Services.AddScoped<ICrushedGrainsGravelTestManager, CrushedGrainsGravelTestManager>();
builder.Services.AddScoped<ICrushabilityGravelTestManager, CrushabilityGravelTestManager>();
builder.Services.AddScoped<IClayInLumpsGravelTestManager, ClayInLumpsGravelTestManager>();
builder.Services.AddScoped<IBulkDensityGravelTestManager, BulkDensityGravelTestManager>();

builder.Services.AddScoped<IMoistureSandTestManager, MoistureSandTestManager>();
builder.Services.AddScoped<IDustSandTestManager, DustSandTestManager>();
builder.Services.AddScoped<IBulkDensitySandTestManager, BulkDensitySandTestManager>();

builder.Services.AddScoped<IBulkDensitySandAndGravelTestManager, BulkDensitySandAndGravelTestManager>();

builder.Services.AddScoped<IFiltrationPlaneGeotextileTestManager, FiltrationPlaneGeotextileTestManager>();

builder.Services.AddScoped<ITestsManager, TestsManager>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IDimensionManager, DimensionManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
