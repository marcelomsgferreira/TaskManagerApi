using App.Adapters.Dtos;
using App.Domain.Entities;

namespace App.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<TodoTask>> GetAllTasks();
        public Task<TodoTask?> FindTaskById(int id);
        public Task AddTask(PostTaskDto taskDto);
        public Task RemoveTask(int id);
    }
}
