using BloggingAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Dtos;
using TodoListAPI.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        //GET /api/todos
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<TodoDto>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<PagedResponse<TodoDto>>> GetTodos(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var todoDtos = await _todoService.GetTodosAsync(pageNumber, pageSize);
                return Ok(todoDtos);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        //GET /api/todos/1
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TodoDto>> GetTodoById(int id)
        {
            try
            {
                var todoDto = await _todoService.GetTodoById(id);
                return todoDto is null ? NotFound() : Ok(todoDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }

        }

        //POST /api/todos
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(TodoDto), 201)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<TodoDto>> CreateTodo(TodoCreateDto dto)
        {
            try
            {
                var todoDto = await _todoService.CreateTodoAsync(dto);
                return CreatedAtAction(nameof(GetTodoById), new { id = todoDto.Id }, todoDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        //PUT /api/todos/1
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TodoDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TodoDto>> UpdateTodo(int id, TodoCreateDto dto)
        {
            try
            {
                var response = await _todoService.UpdateTodoAsync(id, dto);
                return response is null ? NotFound() : Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex) when (ex.Message == "Forbidden")
            {
                return Forbid();
            }
        }

        //DELETE /api/todos/1
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                bool deleted = await _todoService.DeleteTodoAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex) when (ex.Message == "Forbidden")
            {
                return Forbid();
            }
        }

    }
}
