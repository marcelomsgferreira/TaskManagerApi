using App.Adapters.Dtos;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Adapters.Mappers
{
    public static class TaskMapper
    {
        public static GetTaskDto EntityToDTO(this TodoTask entityTask)
        {
            GetTaskDto dto = new GetTaskDto()
            {
                Title = entityTask.Title,
                Description = entityTask.Description,
                DueDate = entityTask.DueDate,
                Category = entityTask.Category,
                Status = entityTask.Status,
                IsCompleted = entityTask.IsCompleted,
                CreatedAt = entityTask.CreatedAt,
                ChangedAt = entityTask.ChangedAt
            };

            return dto;
        }

        public static TodoTask PostDTOtoEntity(this PostTaskDto taskDto, int id)
        {
            TodoTask task = new()
            {
                Id = id,
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Category = taskDto.Category,
                Status = taskDto.Status,
                IsCompleted = false,
                CreatedAt = DateTimeOffset.Now,
                ChangedAt = null
            };

            return task;
        }
    }
}
