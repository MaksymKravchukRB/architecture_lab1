using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskItem CreateTask(TaskItem task)
    {
        // Business logic: validation, defaults, etc.
        if (string.IsNullOrWhiteSpace(task.Title))
            throw new ArgumentException("Title cannot be empty.");

        return _repository.Save(task);
    }

    public IEnumerable<TaskItem> GetAllTasks() => _repository.GetAll();

    public TaskItem? GetTaskById(string id) => _repository.GetById(id);

    public TaskItem UpdateTask(string id, TaskItem updatedTask)
    {
        var existing = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Task with id {id} not found.");

        existing.Title = updatedTask.Title;
        existing.Description = updatedTask.Description;
        existing.Status = updatedTask.Status;
        // CreatedAt remains unchanged

        return _repository.Update(existing);
    }

    public bool DeleteTask(string id)
    {
        if (_repository.GetById(id) == null)
            throw new KeyNotFoundException($"Task with id {id} not found.");
        return _repository.Delete(id);
    }
}