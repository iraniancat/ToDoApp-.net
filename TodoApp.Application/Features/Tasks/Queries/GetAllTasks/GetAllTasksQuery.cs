using MediatR;
using System.Collections.Generic;

namespace TodoApp.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
    }
}
