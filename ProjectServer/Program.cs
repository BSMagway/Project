using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectServer.Interfaces.Services;
using ProjectServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Solution = LaboratoryTest
// LaboratoryTest.WpfApp
// LaboratoryTest.WebApi
// LaboratoryTest.WebApi.Tests
// LaboratoryTest.Common

// N-Layer Tier архитектура (почитать)

// JWT Auth (https://jasonwatmore.com/post/2021/12/14/net-6-jwt-authentication-tutorial-with-example-api)
// Serilog, Worker (Coravel)
// Проработать async-await для сервисов
// Почитать про *.resx и зачем используется

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Визуализация WebApi контроллеров

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMoistureSoilTestService, MoistureSoilTestService>();
builder.Services.AddScoped<IFullShortListTestsService, FullShortListTestsService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
