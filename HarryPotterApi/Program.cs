using System.Text;
using System.Text.Json;
using Api.Data.Connections;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .Build();

var connectionString = config.GetValue<string>("HarryPotterDbConnectionString");
var jwtSecret = config.GetValue<string>("JwtSecret");

var builder = WebApplication.CreateBuilder();

// Add Log system
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddJsonConsole(options =>
{
    options.IncludeScopes = true;
    options.TimestampFormat = "hh:MM:ss ";
    options.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true
    };
});

// Add Database context
builder.Services.AddDbContext<HarryPotterApiDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<DataSeedingService>();
builder.Services.AddSingleton<IJwtService>(new JwtService(jwtSecret));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(jwtSecret);
builder.Services.AddAuthentication(i =>
    {
        i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(i =>
    {
        
        i.RequireHttpsMetadata = false;
        i.SaveToken = true;
        i.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Populate Database
    await app.Services.CreateScope().ServiceProvider.GetRequiredService<DataSeedingService>().Run();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();