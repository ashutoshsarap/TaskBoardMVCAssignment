using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class TaskItem
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")] 
        public string Description { get; set; } 
        public TaskStatus CurrentStatus { get; set; }
    }

    
}
