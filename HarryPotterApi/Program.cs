using HarryPotterApi.Data.Connections;
using HarryPotterApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .Build();

var connectionString = config.GetValue<string>("HarryPotterDbConnectionString");
var imagesBaseUrl = config.GetValue<string>("ImagesBaseUrl");

var builder = WebApplication.CreateBuilder();

// Add Log system
builder.Logging.SetMinimumLevel(LogLevel.Error);
builder.Logging.AddConsole();

// Add Database context
builder.Services.AddDbContext<HarryPotterApiDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<DataSeedingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configurations =>
    {
        configurations.EnableAnnotations();
        configurations.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "Harry Potter API",
                Version = "v1",
                License = new OpenApiLicense { Name = "MIT License", Url = new Uri("https://github.com/diegodrf/HarryPotterApi/blob/main/LICENSE.md") },
                Contact = new OpenApiContact
                {
                    Name = "Diego Faria",
                    Url = new Uri("https://github.com/diegodrf")
                }
            });
    }
    );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Populate Database
    await app.Services
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<DataSeedingService>()
        .Run(imagesBaseUrl);
}

app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.DocumentTitle = "Harry Potter API";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();