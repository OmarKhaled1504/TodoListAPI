namespace TodoListAPI.Dtos;

public record class UserCreateDto(
    string Username,
    string Password,
    string Email
);
