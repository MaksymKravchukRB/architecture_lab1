using TaskManager.Models;

namespace TaskManager.Repositories;

public interface ITaskRepository
{
    TaskItem Save(TaskItem task);
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(string id);
    TaskItem Update(TaskItem task);
    bool Delete(string id);
}