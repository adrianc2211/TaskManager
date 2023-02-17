using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagerApp.Authorizations;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    [Auth("admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}