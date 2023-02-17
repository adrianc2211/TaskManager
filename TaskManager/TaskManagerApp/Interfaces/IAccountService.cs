using TaskManagerApp.Models;
using TaskManagerApp.ViewModels;
using TaskManagerApp.ViewModels.Account;

namespace TaskManagerApp.Interfaces
{
    public interface IAccountService
    {
       bool CreateAccount(RegisterViewModel registerViewModel);
       User Login(LoginViewModel loginViewModel);
    }
}
