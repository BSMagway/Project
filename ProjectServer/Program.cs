using Microsoft.EntityFrameworkCore;
using ProjectServer.Data;
using ProjectServer.Services;
using ProjectServer.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMoistureSoilTestService, MoistureSoilTestService>();
builder.Services.AddScoped<IFullShortListTestsService, FullShortListTestsService>();
builder.Services.AddScoped<ICostumersService, CostumersService>();
//builder.Services.AddManagedSingleton<IDbService>(null);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
