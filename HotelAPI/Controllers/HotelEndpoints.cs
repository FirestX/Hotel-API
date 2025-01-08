using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers;

public abstract class HotelEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/rooms", async (IEntityService<Room> roomService, Room room) =>
        {
            var newRoom = await roomService.AddAsync(room);
            return Results.Created($"/rooms/{newRoom.id}", newRoom);
        });
        
        app.MapDelete("/rooms/{id:int}", async (IEntityService<Room> roomService, int id) =>
        {
            var room = await roomService.GetByIdAsync(id);
            if (room == null)
            {
                return Results.NotFound();
            }
            await roomService.DeleteAsync(room);
            return Results.NoContent();
        });

        app.MapGet("/rooms/{id}", async (IEntityService<Room> roomService, int id) =>
        {
            var room = await roomService.GetByIdAsync(id);
            return room == null ? Results.NotFound() : Results.Ok(room);
        });

        app.MapGet("/rooms", async (IEntityService<Room> roomService) => await roomService.GetAllAsync());
        app.MapGet("/rooms/available", async (HotelDb db) => await db.Rooms.Where(r => r.isAvailable).ToListAsync());
        app.MapGet("/rooms/unavailable", async (HotelDb db) => await db.Rooms.Where(r => !r.isAvailable).ToListAsync());
        app.MapPost("/rooms/{id:int}/bookings", async (IRoomService roomService, int id, Client client) =>
        {
            var room = await roomService.BookRoomAsync(id, client);
            return room == null ? Results.NotFound() : Results.Created($"/rooms/{id}/bookings", client);
        });
        app.MapDelete("/rooms/{id:int}/unbook", async (IRoomService roomService, int id) =>
        {
            var room = await roomService.UnbookRoomAsync(id);
            return room == null ? Results.NotFound() : Results.Created($"/rooms/{id}/unbook", room);
        });

        app.MapPost("/clients", async (IEntityService<Client> clientService, Client client) =>
        {
            var newClient = await clientService.AddAsync(client);
            return Results.Created($"/clients/{newClient.id}", newClient);
        });

        app.MapGet("/clients/{id:int}", async (IEntityService<Client> clientService, int id) =>
        {
            var client = await clientService.GetByIdAsync(id);
            return client == null ? Results.NotFound() : Results.Ok(client);
        });

        app.MapGet("/clients", async (IEntityService<Client> clientService) => await clientService.GetAllAsync());
    }
}