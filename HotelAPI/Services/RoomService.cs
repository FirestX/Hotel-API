using HotelAPI.Data;
using HotelAPI.Models;

namespace HotelAPI.Services;

public class RoomService : IRoomService
{
    private readonly HotelDb _db;
    public RoomService(HotelDb db)
    {
        _db = db;
    }
    public async Task<Room?> BookRoomAsync(int roomId, Client client)
    {
        var room = await _db.Rooms.FindAsync(roomId);
        if (room is not { isAvailable: true })
        {
            return null;
        }

        var existingClient = await _db.Clients.FindAsync(client.id);
        if (existingClient == null)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            existingClient = client;
        }

        room.Book(existingClient);
        await _db.SaveChangesAsync();
        return room;
    }

    public async Task<Room?> UnbookRoomAsync(int roomId)
    {
        var room = await _db.Rooms.FindAsync(roomId);
        if (room == null || room.isAvailable)
        {
            return null;
        }

        room.Unbook();
        await _db.SaveChangesAsync();
        return room;
    }
}