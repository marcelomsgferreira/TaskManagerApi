using App.Domain.Enum;

namespace App.Adapters.Dtos
{
    public class GetTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ChangedAt { get; set; }
    }
}
