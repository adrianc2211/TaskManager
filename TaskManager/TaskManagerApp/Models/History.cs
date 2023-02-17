using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Models
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? TaskId{ get; set; }
        public int? UserId{ get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
    }
}
