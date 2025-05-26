namespace TodoListAPI.Dtos;

public record class TodoDto(
    int Id,
    string Title,
    string? Description
);
