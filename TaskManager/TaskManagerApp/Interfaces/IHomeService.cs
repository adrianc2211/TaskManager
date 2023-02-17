using TaskManagerApp.ViewModels.Home;

namespace TaskManagerApp.Interfaces
{
    public interface IHomeService
    {
        UserViewModel GetUserViewModel();
        bool AddUser(UserViewModel userViewModel);
        void DeleteUser(string email);

        TaskViewModel GetTaskViewModel(bool adminMode, int userId);
        bool AddTask(TaskViewModel userViewModel);
        void DeleteTask(string title);

        HistoryViewModel GetHistoryViewModel();
        bool AddTaskToUser(HistoryViewModel historyViewModel);

        bool UpdateTask(string detailDescription, string title);
    }
}
