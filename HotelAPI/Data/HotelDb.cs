using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data;

public class HotelDb(DbContextOptions<HotelDb> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
}