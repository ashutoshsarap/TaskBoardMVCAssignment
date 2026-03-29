using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class TaskDTO
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus CurrentStatus { get; set; }
    }
}
