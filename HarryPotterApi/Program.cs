using HarryPotterApi.Constants;
using HarryPotterApi.Data.Connections;
using HarryPotterApi.DependencyIntjections;
using HarryPotterApi.Repositories;
using HarryPotterApi.Repositories.contracts;
using HarryPotterApi.Services;
using HarryPotterApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var connectionString = config.GetValue<string>(ConfigurationConstants.HarryPotterDbConnectionString);
var imagesBaseUrl = config.GetValue<string>(ConfigurationConstants.ImagesBaseUrl);
var charactersDataSource = config.GetValue<string>(ConfigurationConstants.CharactersDataSource);
var paginationItemsPerPage = config
    .GetRequiredSection(ConfigurationConstants.Pagination)
    .GetValue<int>(ConfigurationConstants.ItemsPerPage);

var builder = WebApplication.CreateBuilder();

// Add Log system
builder.Logging.SetMinimumLevel(LogLevel.Error);
builder.Logging.AddConsole();

builder.Services.AddDbContext<HarryPotterApiDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
builder.Services.AddScoped<IHousesRepository, HousesRepository>();
builder.Services.AddTransient<IPaginatorService>(_ => new PaginatorService(paginationItemsPerPage));
builder.Services.AddScoped<DataSeedingService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Populate Database
    using var scope = app.Services.CreateScope();
    var provider = scope.ServiceProvider;
    using var seed = new DataSeedingService(
        provider.GetRequiredService<HarryPotterApiDbContext>(),
        new Uri(imagesBaseUrl),
        new Uri(charactersDataSource)
        );
    await seed.Run();
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