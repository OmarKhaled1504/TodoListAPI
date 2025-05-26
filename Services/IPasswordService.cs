using System;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;

namespace TodoListAPI.Services;

public interface IPasswordService
{
    public string HashPassword(User user, string password);

}
