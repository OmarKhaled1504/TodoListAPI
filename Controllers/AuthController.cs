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
        [ProducesResponseType(typeof(User), 201)]
        public async Task<ActionResult<User>> Register(UserCreateDto dto)
        {
            var response = await _authService.RegisterAsync(dto);
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
