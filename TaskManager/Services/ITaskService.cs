using TaskManager.Models;

namespace TaskManager.Services;

public interface ITaskService
{
    TaskItem CreateTask(TaskItem task);
    IEnumerable<TaskItem> GetAllTasks();
    TaskItem? GetTaskById(string id);
    TaskItem UpdateTask(string id, TaskItem updatedTask);
    bool DeleteTask(string id);
}