using System;
using Microsoft.AspNetCore.Identity;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Services.AuthServices;

public class PasswordService : IPasswordService
{
    private readonly PasswordHasher<User> _hasher = new();
    public string HashPassword(User user, string password)
    {

        return _hasher.HashPassword(user, password);
    }

    public bool Verify(User user, string password, string hashed)
    {
        return _hasher.VerifyHashedPassword(user, hashed, password) == PasswordVerificationResult.Success;
    }
}
