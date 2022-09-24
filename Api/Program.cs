using Api.Data.Connections;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var connectionString = config.GetConnectionString("HarryPotterDb");

var builder = WebApplication.CreateBuilder();

// Add Database context
builder.Services.AddDbContext<HarryPotterApiDbContext>(options => 
    options.UseNpgsql(connectionString)
    // options.UseInMemoryDatabase("ABC")
    );

// Add services to the container.
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<DataSeedingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.Services.CreateScope().ServiceProvider.GetRequiredService<DataSeedingService>().Run();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();