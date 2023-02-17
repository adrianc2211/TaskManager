using System.Security;
using TaskManagerApp.DbContexts;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Models;
using TaskManagerApp.ViewModels;
using TaskManagerApp.ViewModels.Account;

namespace TaskManagerApp.Services
{
    // AccountService dla środowiska produkcyjnego
    public class AccountServiceProd : IAccountService
    {
        public DataContext dataContext { get; set; }
        public AccountServiceProd(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public bool CreateAccount(RegisterViewModel registerViewModel)
        {
            bool userExist = dataContext.Users.Where(x => x.Email == registerViewModel.Email).Any();

            if (!userExist)
            {
                User user = new User
                {
                    CellPhone = registerViewModel.CellPhone,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Password = registerViewModel.Password,
                    Role = "normal"
                };

                if (user.Email.ToLower().Contains("admin"))
                {
                    user.Role = "admin";
                }

                dataContext.Users.Add(user);
                dataContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        public User Login(LoginViewModel loginViewModel)
        {
            var appUser = dataContext.Users.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

            return appUser;
        }
    }
}
