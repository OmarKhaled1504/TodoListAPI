using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using TodoListAPI.Entities;

namespace TodoListAPI.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<Todo> Todos => Set<Todo>();
}
