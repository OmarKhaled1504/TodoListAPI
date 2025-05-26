using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<UserDto>> RegisterAsync(UserCreateDto dto)
    {
        User user = dto.ToEntity();
        var hash = _passwordService.HashPassword(dto, user);
        user.PasswordHash = hash;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.ToDto();
    }
}
