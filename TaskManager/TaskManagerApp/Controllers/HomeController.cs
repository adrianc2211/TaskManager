using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagerApp.Authorizations;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Models;
using TaskManagerApp.ViewModels.Home;

namespace TaskManagerApp.Controllers
{
    
    public class HomeController : Controller
    {
        public IHomeService homeService { get; set; }
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Auth("admin")]
        [HttpGet]
        public IActionResult AddUser()
        {
            var model = homeService.GetUserViewModel();
            return View(model);
        }
        [Auth("admin")]
        [HttpPost]
        public IActionResult AddUser(UserViewModel userViewModel)
        {
            var model = homeService.GetUserViewModel();
            if (ModelState.IsValid)
            {
                var userExist = homeService.AddUser(userViewModel);

                if (userExist)
                {
                    ViewData["Message"] = "Taki użytkownik już istanieje";

                    return View(model);
                }

                return View(model);
            }
            else
            {
                return View(model);
            }
        }
        [Auth("admin")]
        [HttpGet]
        public IActionResult DeleteUser(string email)
        {
            homeService.DeleteUser(email);

            return RedirectToAction("AddUser", "Home");
        }
        [Auth("admin, normal")]
        [HttpGet]
        public IActionResult AddTask()
        {
            var model = homeService.GetTaskViewModel();
            return View(model);
        }


        [Auth("admin, normal")]
        [HttpPost]
        public IActionResult AddTask(TaskViewModel taskViewModel)
        {
            var model = homeService.GetTaskViewModel();

            ModelState.Remove("TaskList");
   
            if (ModelState.IsValid)
            {
                var taskExsit = homeService.AddTask(taskViewModel);

                if (taskExsit)
                {
                    ViewData["Message"] = "Takie zadanie/kod statusu już istnieje";

                    return View(model);
                }

                return RedirectToAction("AddTask", "Home");
            }
            else
            {
                return View(model);
            }
        }
        [Auth("admin")]
        [HttpGet]
        public IActionResult DeleteTask(string title)
        {
            homeService.DeleteTask(title);

            return RedirectToAction("AddTask", "Home");
        }
        [Auth("admin")]
        [HttpGet]
        public IActionResult AddTaskToUser()
        {
            var model = homeService.GetHistoryViewModel();
            return View(model);
        }
        [Auth("admin")]
        [HttpPost]
        public IActionResult AddTaskToUser(HistoryViewModel historyViewModel)
        {
            var model = homeService.GetHistoryViewModel();
            ModelState.Remove("HistoryList");

            if (ModelState.IsValid)
            {
                var notExist = homeService.AddTaskToUser(historyViewModel);

                if (notExist)
                {
                    ViewData["Message"] = "Nie istnieje zadanie/użytkownik o podanym identyfikatorze";

                    return View(model);
                }

                return RedirectToAction("AddTaskToUser", "Home");
            }
            else
            {
                return View(model);
            }
        }
        [Auth("admin")]
        [HttpPost]
        public IActionResult UpdateTask(string detailDescription, string title)
        {
            var model = homeService.GetTaskViewModel();

            if (detailDescription != null)
            {
                var notExistTask = homeService.UpdateTask(detailDescription, title);
                if (notExistTask)
                {
                    ViewData["Message"] = "Zadanie o podanym id nie istnieje";
                }
                else
                {
                    return RedirectToAction("AddTask", "Home", model);
                }
            }
            else
            {
                ViewData["Message"] = "Dodatkowy opis nie może być pusty";
            }

            return RedirectToAction("AddTask", "Home", model);
        }
    }
}