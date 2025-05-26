using System;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Services.AuthServices;

public interface IPasswordService
{
    public string HashPassword(User user, string password);
    public bool Verify(User user, string password, string hashed);

}
