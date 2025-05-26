namespace TodoListAPI.Dtos;

public record class TodoCreateDto(
    string Title,
    string? Description
);
