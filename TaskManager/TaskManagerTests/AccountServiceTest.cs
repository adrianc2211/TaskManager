using Bogus;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManagerApp.DbContexts;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Models;
using TaskManagerApp.Services;
using TaskManagerApp.ViewModels.Home;

namespace TaskManagerTests
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void add_new_account()
        {
            var data = GenerateData(1).AsQueryable();
            var mockDataContext = new Mock<DataContext>();
            var mockSet = new Mock<DbSet<User>>();


            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockDataContext.Setup(x => x.Users).Returns(mockSet.Object);

            IHomeService service = new HomeService(mockDataContext.Object);

            UserViewModel userViewModel = new UserViewModel
            {
                CellPhone = data.FirstOrDefault().CellPhone,
                ConfirmPassword = data.FirstOrDefault().Password,
                Email = data.FirstOrDefault().Email,
                FirstName = data.FirstOrDefault().FirstName,
                LastName = data.FirstOrDefault().LastName
            };

            service.AddUser(userViewModel);
        }

        //UserViewModel GetUserViewModel();
        //bool AddUser(UserViewModel userViewModel);
        //void DeleteUser(string email);

        //TaskViewModel GetTaskViewModel();
        //bool AddTask(TaskViewModel userViewModel);
        //void DeleteTask(string title);

        //HistoryViewModel GetHistoryViewModel();
        //bool AddTaskToUser(HistoryViewModel historyViewModel);

        //bool UpdateTask(string detailDescription, string title);
        private List<User> GenerateData(int count)
        {
            var faker = new Faker<User>()
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.CellPhone, f => f.Phone.Random.ToString())
                .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                .RuleFor(c => c.LastName, f => f.Person.LastName)
                .RuleFor(c => c.Role, f => "admin")
                .RuleFor(c => c.Password, f => "password");

            return faker.Generate(count);
        }
    }

  
}