using App.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities

{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }  

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }  

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }  

        [Required(ErrorMessage = "DueDate is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [CustomValidation(typeof(Task), "ValidateDueDate")]
        public DateTimeOffset DueDate { get; set; }  

        [Required(ErrorMessage = "Category is required.")]
        public Category Category { get; set; }  

        [Required(ErrorMessage = "Status is required.")]
        public Status Status { get; set; }  
        public bool IsCompleted { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(Task), "ValidateCreatedAt")]
        public DateTimeOffset CreatedAt { get; set; } 

        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(Task), "ValidateChangedAt")]
        public DateTimeOffset? ChangedAt { get; set; }  

    }
}
