using Microsoft.EntityFrameworkCore;
using Server.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext with the PostgreSQL connection string
builder.Services.AddDbContext<ServerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CookieDatabase")));

builder.Services.AddSingleton<Market>();

// Register the MarketPriceService
builder.Services.AddHostedService<MarketPriceService>();

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
