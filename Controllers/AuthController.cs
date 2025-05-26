using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //POST /api/auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<UserDto>> Register(UserCreateDto dto)
        {
            var response = await _authService.RegisterAsync(dto);

            return response is null ? BadRequest("Username or Email already exist.") : StatusCode(201, response);
        }

    }
}
