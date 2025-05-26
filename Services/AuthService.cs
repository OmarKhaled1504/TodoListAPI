using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;
using TodoListAPI.Mapping;

namespace TodoListAPI.Services;

public class AuthService : IAuthService
{
    private readonly TodoContext _context;
    private readonly IPasswordService _passwordService;
    public AuthService(TodoContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;

    }
    public async Task<UserDto?> RegisterAsync(UserCreateDto dto)
    {
        if (await _context.Users.AnyAsync(user =>
    user.Username == dto.Username || user.Email == dto.Email))
        {
            return null;
        }

        User user = dto.ToEntity();
        var hash = _passwordService.HashPassword(user, dto.Password);
        user.PasswordHash = hash;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.ToDto();
    }
}
