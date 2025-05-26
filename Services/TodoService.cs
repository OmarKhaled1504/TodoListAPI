using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;
using TodoListAPI.Mapping;
using System.Security.Claims;
using BloggingAPI.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Services;

public class TodoService : ITodoService
{
    private readonly TodoContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TodoService(TodoContext todoContext, IHttpContextAccessor httpContextAccessor)
    {
        _context = todoContext;
        _httpContextAccessor = httpContextAccessor;
    }



    public async Task<PagedResponse<TodoDto>?> GetTodosAsync(int pageNumber, int pageSize)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdStr) || !int.TryParse(userIdStr, out int userId))
            throw new UnauthorizedAccessException("User not authenticated");

        var query = _context.Todos
        .Include(todo => todo.User)
        .Where(todo => todo.UserId == userId)
        .AsQueryable();
        var totalCount = await query.CountAsync();
        var todos = await query
        .Include(todo => todo.User)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(todo => todo.ToDto())
        .ToListAsync();

        return new PagedResponse<TodoDto>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            Data = todos
        };
    }
    public async Task<TodoDto?> GetTodoById(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo is null)
        {
            return null;
        }
        var user = _httpContextAccessor.HttpContext?.User;
        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdStr) || !int.TryParse(userIdStr, out int userId))
            throw new UnauthorizedAccessException("User not authenticated");
        if (todo.UserId != userId)
            throw new UnauthorizedAccessException();
        return todo.ToDto();
    }
    public async Task<TodoDto> CreateTodoAsync(TodoCreateDto dto)
    {

        var user = _httpContextAccessor.HttpContext?.User;

        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdStr) || !int.TryParse(userIdStr, out int userId))
            throw new UnauthorizedAccessException("User not authenticated");
        var todo = dto.ToEntity();
        todo.UserId = userId;
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return todo.ToDto();
    }

    public async Task<TodoDto?> UpdateTodoAsync(int id, TodoCreateDto dto)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
            return null;

        var user = _httpContextAccessor.HttpContext?.User;
        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdStr) || !int.TryParse(userIdStr, out int userId))
            throw new UnauthorizedAccessException("User not authenticated");

        if (todo.UserId != userId)
            throw new Exception("Forbidden");
        todo.Title = dto.Title;
        todo.Description = dto.Description;
        await _context.SaveChangesAsync();
        return todo.ToDto();
    }

    public async Task<bool> DeleteTodoAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
        {
            return false;
        }

        var user = _httpContextAccessor.HttpContext?.User;
        var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdStr) || !int.TryParse(userIdStr, out int userId))
            throw new UnauthorizedAccessException("User not authenticated");

        if (todo.UserId != userId)
            throw new Exception("Forbidden");

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }

}
