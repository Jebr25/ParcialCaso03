using Microsoft.EntityFrameworkCore;
using ParcialCaso03.DOMAIN.Core.Interfaces;
using ParcialCaso03.DOMAIN.Infrastructure.Data;
using ParcialCaso03.DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<Dpa202302parcialCaso0320200136Context>(options => options.UseSqlServer(_cnx));

// Add Interfaces
builder.Services.AddTransient<ITerritoryRepository, TerritoryRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
