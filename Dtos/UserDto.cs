using TodoListAPI.Entities;

namespace TodoListAPI.Dtos;

public record class UserDto(
    string Username,
    string Email
);
