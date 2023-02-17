using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Models;

namespace TaskManagerApp.ViewModels.Home
{
    public class HistoryViewModel
    {
        [Required(ErrorMessage = "Identyfiaktor zadania jest wymagany")]
        public int? TaskId { get; set; }
        [Required(ErrorMessage = "Identyfiaktor użytkownika jest wymagany")]
        public int? UserId { get; set; }
        public string Note { get; set; } = string.Empty;
        public List<History> HistoryList { get; set; }
    }
}
