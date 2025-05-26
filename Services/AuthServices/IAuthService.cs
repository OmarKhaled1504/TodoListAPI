using System;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dtos;

namespace TodoListAPI.Services.AuthServices;

public interface IAuthService
{
    public Task<string?> RegisterAsync(UserCreateDto dto);
    public Task<string> LoginAsync(LoginDto dto);
}
