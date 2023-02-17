using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class StatusCode
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
