using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;
using TodoListAPI.Mapping;

namespace TodoListAPI.Services.AuthServices;

public class AuthService : IAuthService
{
    private readonly TodoContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    public AuthService(TodoContext context, IPasswordService passwordService, ITokenService tokenService)
    {
        _context = context;
        _passwordService = passwordService;
        _tokenService = tokenService;

    }
    public async Task<string?> RegisterAsync(UserCreateDto dto)
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
        var token = _tokenService.GenerateToken(user);
        return token;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == dto.Email);
        if (user is null)
            throw new Exception("User with this email not found.");
        var authenticated = _passwordService.Verify(user, dto.Password,user.PasswordHash);
        if (!authenticated)
            throw new Exception("Password Incorrect.");
        return _tokenService.GenerateToken(user);
    }
}
