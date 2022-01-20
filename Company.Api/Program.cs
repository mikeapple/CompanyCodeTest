using Company.Api.Services;
using Company.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientModels = Company.Common.ClientModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var filePath = @"..\InchecapData.db";
var connectionString = $@"Data Source={filePath}";

builder.Services.AddDbContext<CompanyContext>(o => o.UseSqlite(connectionString));
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/makes", ([FromServices] IVehicleService vehicleService) =>
{
    return vehicleService.GetMakes();
})
.WithName("GetMakes");

app.MapGet("/aprdetails", ([FromServices] IVehicleService vehicleService) =>
{
    return vehicleService.GetAprDetails();
})
.WithName("GetAprDetials");

app.MapPost("/makes", ([FromServices] IVehicleService vehicleService, [FromBodyAttribute] string text) =>
{
    return vehicleService.AddMake(text);
})
.WithName("AddMake");

app.MapPost("/aprdetails", ([FromServices] IVehicleService vehicleService, [FromBodyAttribute] ClientModels.AprDetails aprDetails) =>
{
    return vehicleService.AddAprDetails(
        aprDetails.MakeId,
        aprDetails.VehicleTypeId,
        aprDetails.QuoteTypeId,
        aprDetails.ZeroToThreeMonthApr,
        aprDetails.ThreeToSixMonthApr,
        aprDetails.SixToTwelveMonthApr,
        aprDetails.OverTwelveMonthApr);
})
.WithName("AddAprDetails");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}