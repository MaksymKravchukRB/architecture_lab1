namespace TaskManager.Models;

public class Task
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.New;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum TaskStatus
{
    New,
    InProgress,
    Done
}