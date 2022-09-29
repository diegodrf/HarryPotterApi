using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Models.Data;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }

    [DataType(DataType.EmailAddress)] 
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsBlocked { get; set; } = false;

    public bool PasswordMatch(string password)
    {
        return Password.Equals(password);
    }
}