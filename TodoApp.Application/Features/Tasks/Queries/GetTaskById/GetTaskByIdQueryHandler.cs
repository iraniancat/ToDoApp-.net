using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Features.Tasks.Queries.GetAllTasks;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (task == null)
                return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt
            };
        }
    }
}
