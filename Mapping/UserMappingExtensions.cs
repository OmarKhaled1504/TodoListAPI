using System;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Mapping;

public static class UserMappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
            user.Username,
            user.Email
        );
    }

    public static User ToEntity(this UserCreateDto dto)
    {
        return new User
        {
            Username = dto.Username,
            Email = dto.Email
        };
    }
}
