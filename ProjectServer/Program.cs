﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectServer.Data;
using ProjectServer.Interfaces.Managers;
using ProjectServer.Interfaces.Managers.MaterialTests.Gravel;
using ProjectServer.Interfaces.Managers.MaterialTests.Soil;
using ProjectServer.Managers;
using ProjectServer.Managers.MaterialTests.Gravel;
using ProjectServer.Managers.MaterialTests.Soil;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Solution = LaboratoryTest
// LaboratoryTest.WpfApp
// LaboratoryTest.WebApi
// LaboratoryTest.WebApi.Tests
// LaboratoryTest.Common

// N-Layer Tier архитектура (почитать)

// JWT Auth (https://jasonwatmore.com/post/2021/12/14/net-6-jwt-authentication-tutorial-with-example-api)
//https://www.c-sharpcorner.com/article/jwt-authentication-and-authorization-in-net-6-0-with-identity-framework/

// Serilog, Worker (Coravel)
// Проработать async-await для сервисов
// Почитать про *.resx и зачем используется

// UnitOfWork (https://metanit.com/sharp/mvc5/23.3.php)
// Лучше использовать подход EF Core Migrations (https://metanit.com/sharp/entityframeworkcore/2.15.php)

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddScoped<IMoistureSoilTestManager, MoistureSoilTestManager>();
builder.Services.AddScoped<IDensitySoilTestManager, DensitySoilTestManager>();
builder.Services.AddScoped<IYieldLimitSoilTestManager, YieldLimitSoilTestManager>();
builder.Services.AddScoped<IRollingBoundarySoilTestManager, RollingBoundarySoilTestManager>();

builder.Services.AddScoped<IMoistureGravelTestManager, MoistureGravelTestManager>();

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
