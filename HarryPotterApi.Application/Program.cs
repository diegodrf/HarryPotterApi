using HarryPotterApi.Infrastructure;
using HarryPotterApi.Infrastructure.Database;
using HarryPotterApi.Infrastructure.Repositories;
using HarryPotterApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>().Build();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString(Constants.HarryPotterDbConnectionString);
builder.Services.AddDbContext<HarryPotterApiDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddTransient<IPaginationService, PaginationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
