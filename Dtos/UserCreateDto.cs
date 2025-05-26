using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Dtos;

public record class UserCreateDto(
    [Required]string Username,
    [Required]string Password,
    [Required]string Email
);
