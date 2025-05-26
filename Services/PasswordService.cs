using System;
using Microsoft.AspNetCore.Identity;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(UserCreateDto dto, User user)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(user, dto.Password);
    }
}
