using System;
using TodoListAPI.Entities;

namespace TodoListAPI.Services.AuthServices;

public interface ITokenService
{
    string GenerateToken(User user);
}
