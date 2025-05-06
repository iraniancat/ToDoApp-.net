namespace TodoApp.Application.Features.Tasks.Queries.GetAllTasks
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
