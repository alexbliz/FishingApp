using Microsoft.EntityFrameworkCore;
using FishingApp.Data;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Remove this line if GeoJsonConverterFactory is causing issues
    // options.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FishingApp API", Version = "v1" });
});

// Get the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("FishingDatabase");

// Add DbContext service with the connection string
builder.Services.AddDbContext<FishingContext>(options =>
    options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FishingApp API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
