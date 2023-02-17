using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Enums
{
    public enum TaskStatusCodes
    {

        [Display(Name = "Do zrobienia")]
        Todo = 0,
        [Display(Name = "W trakcie")]
        InProgress = 1,
        [Display(Name = "Faza testów")]
        Testing = 2,
        [Display(Name = "Zakończono")]
        Finished = 3
    }
}
