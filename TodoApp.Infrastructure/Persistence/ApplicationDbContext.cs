using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Application.Interfaces;

namespace TodoApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TodoTask> Tasks => Set<TodoTask>();
        public DbSet<User> Users { get; set; } = null!;


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);
    }
}
