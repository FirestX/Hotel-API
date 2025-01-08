using HotelAPI.Models;

namespace HotelAPI.Services;

public interface IRoomService
{
    Task<Room?> BookRoomAsync(int roomId, Client client);
    Task<Room?> UnbookRoomAsync(int roomId);
}
