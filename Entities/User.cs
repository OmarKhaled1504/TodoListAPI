using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Entities;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    public int Id { set; get; }
    public string Username { set; get; } = string.Empty;
    public string PasswordHash { set; get; } = string.Empty;
    public string Email { set; get; } = string.Empty;
    public List<Todo> Todos { get; set; } = new();
}
