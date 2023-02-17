using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public int? UserId { get; set; }
        public StatusCode? StatusCode { get; set; }
    }
}
