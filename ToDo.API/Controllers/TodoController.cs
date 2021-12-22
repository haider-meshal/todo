using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using ToDo.API.Commands;
using ToDo.API.Queries;

namespace ToDo.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TodoController : ControllerBase
{
   private readonly IMediator mediator;

   public TodoController(IMediator mediator)
   {
       this.mediator = mediator;
   }

   [HttpGet("~/list_todos")]
   public async Task<IActionResult> ListTodos()
   {
       var result = await mediator.Send(new GetAllTodosQuery());
       return Ok(result);
   }

   [HttpGet("~/get_todo")]
   public async Task<IActionResult> GetTodo(int id)
   {
       GetTodoQuery query = new GetTodoQuery();
       query.id = id;
       var result = await mediator.Send(query);
       return Ok(result);
   }

   [HttpPost("~/create_todo")]
   public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand cmd)
   {
       var result = await mediator.Send(cmd);
       return Ok(result);
   }

   [HttpPut("~/update_todo")]
   public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommand cmd)
   {
       var result = await mediator.Send(cmd);
       return Ok(result);
   }

   [HttpPut("~/update_todo_status")]
   public async Task<IActionResult> UpdateTodoStatus([FromBody] UpdateTodoStatusCommand cmd)
   {
       var result = await mediator.Send(cmd);
       return Ok(result);
   }

   [HttpDelete("~/delete_todo")]
   public async Task<IActionResult> RemoveTodo(int id)
   {
       RemoveTodoCommand cmd = new RemoveTodoCommand();
       cmd.id = id;
       var result = await mediator.Send(cmd);
       return Ok(result);
   }
}
