using MediatR;
using TodoApp.Application.Features.Tasks.Queries.GetAllTasks;

namespace TodoApp.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public Guid Id { get; set; }

        public GetTaskByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
