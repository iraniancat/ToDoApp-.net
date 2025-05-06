using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoTask> Tasks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
