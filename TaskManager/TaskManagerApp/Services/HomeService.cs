﻿using TaskManagerApp.DbContexts;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Models;
using TaskManagerApp.ViewModels.Home;
using System.Linq;

namespace TaskManagerApp.Services
{
    public class HomeService : IHomeService
    {
        public DataContext dataContext { get; set; }
        public HomeService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public UserViewModel GetUserViewModel()
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                UserList = new List<User>()
            }; 
            var users = dataContext.Users;

            if (users != null)
            {
                foreach (var item in users)
                {
                    User user = new User()
                    {
                        CellPhone = item.CellPhone,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        Role = item.Role
                    };

                    userViewModel.UserList.Add(user);
                }
            }

            return userViewModel;
        }

        public void DeleteUser(string email)
        {
            var user = dataContext.Users.FirstOrDefault(x => x.Email == email);
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }

        public bool AddUser(UserViewModel userViewModel)
        {
            var existUser = dataContext.Users.Where(x => x.Email == userViewModel.Email).Any();

            if (existUser)
            {
                return true;
            }

            User user = new User()
            {
                CellPhone = userViewModel.CellPhone,
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Password = userViewModel.Password,
                Role = "normal"
            };

            if (user.Email.ToLower().Contains("admin"))
            {
                user.Role = "admin";
            }

            dataContext.Users.Add(user);
            dataContext.SaveChanges();

            return false;
        }

        public TaskViewModel GetTaskViewModel()
        {
            TaskViewModel taskViewModel = new TaskViewModel()
            {
                TaskList = new List<Models.Task>()
            };

            var tasks = dataContext.Tasks;

            if (tasks != null)
            {
                foreach (var item in tasks)
                { 
                    var task = new Models.Task()
                    {
                        DueDate = item.DueDate,
                        StatusCode = new StatusCode() { Code = item.StatusCode?.Code, Description = item.StatusCode?.Description },
                        Title = item.Title,
                        DetailDescription= item.DetailDescription
                    };
                    
                    taskViewModel.TaskList.Add(task);
                }
            }
      
            return taskViewModel;
        }

        public bool AddTask(TaskViewModel taskViewModel)
        {
            var existTask= dataContext.Tasks.Where(x => x.Title == taskViewModel.Title).Any();
            var existStatus = dataContext.StatusCodes.Where(x => x.Code == taskViewModel.StatusCode).Any();

            if (existTask || existStatus)
            {
                return true;
            }

            var task = new Models.Task()
            {
                DueDate = taskViewModel.DueDate,
                StatusCode = new StatusCode() { Code = taskViewModel.StatusCode, Description = taskViewModel.StatusDescription },
                Title = taskViewModel.Title
            };

            dataContext.Tasks.Add(task);
            dataContext.SaveChanges();

            return false; 
        }

        public void DeleteTask(string title)
        {
            var task = dataContext.Tasks.FirstOrDefault(x => x.Title == title);
            dataContext.Tasks.Remove(task);
            dataContext.SaveChanges();
        }

        public HistoryViewModel GetHistoryViewModel()
        {
            HistoryViewModel taskViewModel = new HistoryViewModel()
            {
                HistoryList = new List<History>()
            };

            var histories = dataContext.Histories;

            if (histories != null)
            {
                foreach (var item in histories)
                {
                    var history = new History()
                    {
                       CreateDate = DateTime.Now,
                       TaskId = item.TaskId,
                       UserId = item.UserId,
                       Note = item.Note,
                    };

                    taskViewModel.HistoryList.Add(history);
                }
            }

            return taskViewModel;
        }

        public bool AddTaskToUser(HistoryViewModel historyViewModel)
        {
            var existTask = dataContext.Tasks.Where(x=>x.Id == historyViewModel.TaskId).Any();
            var existUser = dataContext.Users.Where(x=>x.Id == historyViewModel.UserId).Any();

            if (!existUser || !existTask)
            {
                return true;
            }
            History history = new History
            {
                CreateDate = DateTime.Now,
                TaskId = historyViewModel.TaskId,
                UserId = historyViewModel.UserId,
                Note = historyViewModel.Note
            };

            dataContext.Histories.Add(history);
            dataContext.SaveChanges();

            return false;
        }

        public bool UpdateTask(string detailDescription, string title)
        {
            var task = dataContext.Tasks.FirstOrDefault(x => x.Title == title);
            
            if (task == null)
            {
                return true;
            }

            var newTask = dataContext.Tasks.FirstOrDefault(x => x.Title == title);
            newTask.DetailDescription = detailDescription;
            dataContext.Entry(newTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataContext.SaveChanges();

            return false;
        }
    }
}
