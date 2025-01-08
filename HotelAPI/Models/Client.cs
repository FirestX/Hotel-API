using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models;

public class Client(int id, string name, string email, string phoneNumber)
{
    public int id { get; private set; } = id;

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string name { get; set; } = name;
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string email { get; set; } = email;
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string phoneNumber { get; set; } = phoneNumber;
}