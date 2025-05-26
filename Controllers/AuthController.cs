using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dtos;
using TodoListAPI.Entities;
using TodoListAPI.Services.AuthServices;

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
        [ProducesResponseType(typeof(TokenDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TokenDto?>> Register(UserCreateDto dto)
        {
            var response = await _authService.RegisterAsync(dto);

            return response is null ? BadRequest("Username or Email already exist.") : StatusCode(201, response);
        }

        //POST /api/auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<TokenDto>> Login(LoginDto dto) {
            var token = await _authService.LoginAsync(dto);
            return Ok(new TokenDto(token));
        }

    }
}
