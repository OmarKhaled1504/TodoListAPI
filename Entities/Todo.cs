using System;

namespace TodoListAPI.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int UserId { set; get; } //FK
    public User? User { set; get; }

}
