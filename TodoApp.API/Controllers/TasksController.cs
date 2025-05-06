using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Tasks.Commands.CreateTask;
using TodoApp.Application.Features.Tasks.Commands.DeleteTask;
using TodoApp.Application.Features.Tasks.Commands.UpdateTask;
using TodoApp.Application.Features.Tasks.Queries.GetAllTasks;
using TodoApp.Application.Features.Tasks.Queries.GetTaskById;

namespace TodoApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));

            if (!result)
                return NotFound();

            return NoContent(); // 204
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.Id)
                return BadRequest("Mismatched task ID.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent(); // 204
        }




    }
}
