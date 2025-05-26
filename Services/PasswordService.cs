using System;
using Microsoft.AspNetCore.Identity;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(User user, string password)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(user, password);
    }
}
