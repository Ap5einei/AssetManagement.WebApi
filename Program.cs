using Microsoft.EntityFrameworkCore;
using AssetManagement.WebApi.Data;
using AssetManagement.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Rekisteröidään Microsoft SQL Server -tietokantayhteys (Docker)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Rekisteröidään Repository Dependency Injectionia varten
builder.Services.AddScoped<IAssetRepository, AssetRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Luo automaattisen testisivun (Swagger)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// AUTOMAATIO: Päivittää Docker-kontin SQL-kannan automaattisesti käynnistyksessä
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Virhe tietokannan automaattisessa alustuksessa.");
    }
}

app.Run();
