using System.Collections.Concurrent;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly ConcurrentDictionary<string, TaskItem> _store = new();

    public TaskItem Save(TaskItem task)
    {
        _store[task.Id] = task;
        return task;
    }

    public IEnumerable<TaskItem> GetAll() => _store.Values;

    public TaskItem? GetById(string id) => _store.GetValueOrDefault(id);

    public TaskItem Update(TaskItem task)
    {
        if (!_store.ContainsKey(task.Id))
            throw new KeyNotFoundException($"Task with id {task.Id} not found.");
        _store[task.Id] = task;
        return task;
    }

    public bool Delete(string id) => _store.TryRemove(id, out _);
}