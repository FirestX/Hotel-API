using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models;

public class Room
{
    [Required]
    public int id { get; set; }
    [Required]
    public RoomType type { get; set; }
    [Required]
    public decimal price { get; set; }
    [Required]
    public bool isAvailable { get; set; } = true;

    public int? clientId { get; set; }
    public Client? client { get; set; }

    public void Book(Client client)
    {
        isAvailable = false;
        clientId = client.id;
        this.client = client;
    }

    public void Unbook()
    {
        isAvailable = true;
        clientId = null;
        client = null;
    }
}