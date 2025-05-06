using MediatR;

namespace TodoApp.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
