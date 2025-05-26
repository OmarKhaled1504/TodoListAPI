using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Mapping;

public static class TodoMappingExtensions
{
    public static TodoDto ToDto(this Todo todo)
    {
        return new TodoDto(
            todo.Id,
            todo.Title,
            todo.Description
        );
    }

    public static Todo ToEntity(this TodoCreateDto dto)
    {
        return new Todo
        {
            Title = dto.Title,
            Description = dto.Description
        };
    }
}
