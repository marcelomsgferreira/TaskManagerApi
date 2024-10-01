using App.Adapters.Dtos;
using App.Adapters.Mappers;
using App.Database;
using App.Domain.Entities;
using App.Domain.Enum;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.Repositories
{
    public class TaskRepository(AppDbContext _context) : ITaskRepository
    {

        public async Task AddTask(PostTaskDto taskDto)
        {
            int id = _context.Tasks.Count() + 1;
            TodoTask task = taskDto.PostDTOtoEntity(id);
            await _context.Tasks.AddAsync(task);
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TodoTask?> FindTaskById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task RemoveTask(int id)
        {
            TodoTask? todoTask = await FindTaskById(id);

            _context.Tasks.Remove(todoTask);
        }
    }
}
