using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using TaskManagerApp.Enums;

namespace TaskManagerApp.ViewModels.Home
{
    public class TaskViewModel
    {
       
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Data terminu jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Kod statusu jest wymagany")]
        public TaskStatusCodes StatusCode { get; set; }
        [Required(ErrorMessage = "Opis statusu jest wymagany")]
        public string StatusDescription { get; set; }
        [BindNever]
        public List<Models.Task> TaskList { get; set; }
    }
}
