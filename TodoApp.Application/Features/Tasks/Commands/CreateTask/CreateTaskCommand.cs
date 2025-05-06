using MediatR;

namespace TodoApp.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
