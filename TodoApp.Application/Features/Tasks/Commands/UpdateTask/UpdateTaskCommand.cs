using MediatR;

namespace TodoApp.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
