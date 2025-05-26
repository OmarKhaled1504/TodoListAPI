using System;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dtos;

namespace TodoListAPI.Services;

public interface IAuthService
{
    public Task<UserDto?> RegisterAsync(UserCreateDto dto);
}
