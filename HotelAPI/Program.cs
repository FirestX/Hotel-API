using HotelAPI.Services;
using HotelAPI.Controllers;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hotel Management API",
        Description = "Managing hotel rooms and reservations",
        Version = "v1"
    });
});

var connectionString = builder.Configuration.GetConnectionString("HotelDb") ?? "Data Source=hotel.db";
builder.Services.AddSqlite<HotelDb>(connectionString);
builder.Services.AddScoped<IEntityService<Room>, EntityService<Room>>();
builder.Services.AddScoped<IEntityService<Client>, EntityService<Client>>();
builder.Services.AddScoped<IRoomService, RoomService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Management API V1");
});

app.UseHttpsRedirection();

HotelEndpoints.MapEndpoints(app);

app.Run();
