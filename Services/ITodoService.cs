using System;
using BloggingAPI.Responses;
using TodoListAPI.Dtos;

namespace TodoListAPI.Services;

public interface ITodoService
{
    public Task<PagedResponse<TodoDto>?> GetTodosAsync(int pageNumber, int pageSize);
    public Task<TodoDto?> GetTodoById(int id);
    public Task<TodoDto> CreateTodoAsync(TodoCreateDto dto);
    public Task<TodoDto?> UpdateTodoAsync(int id, TodoCreateDto dto);
}
