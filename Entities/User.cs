using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Entities;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]

public class User
{
    public int Id { set; get; }
    [Required]
    public string Username { set; get; } = string.Empty;
    [Required]
    public string PasswordHash { set; get; } = string.Empty;
    [Required]
    public string Email { set; get; } = string.Empty;
    public List<Todo> Todos { get; set; } = new();
}
