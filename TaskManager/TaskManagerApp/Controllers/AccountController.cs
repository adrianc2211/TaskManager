using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TaskManagerApp.Interfaces;
using TaskManagerApp.ViewModels;
using TaskManagerApp.ViewModels.Account;

namespace TaskManagerApp.Controllers
{
    public class AccountController : Controller
    {
        public IAccountService accountService { get; set; }
        public IHttpContextAccessor accessor;
        public AccountController(IAccountService accountService, IHttpContextAccessor accessor)
        {
            this.accountService = accountService;
            this.accessor = accessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var isCreated = accountService.CreateAccount(registerViewModel);

                if (isCreated)
                {
                    return RedirectToAction("Login", "Account");
                } 
                else
                {
                    ViewData["Message"] = "Takie konto już istnieje";
                    return View();
                }
            }
            else
            {
                return View(registerViewModel);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var httpContext = accessor.HttpContext;

                var appUser = accountService.Login(loginViewModel);

                if (appUser == null)
                {
                    ViewData["Message"] = "Niepoprawne dane logowania";
                    return View(loginViewModel);
                }

                httpContext?.Session.SetString("Role", appUser.Role);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public IActionResult UnAuthorization()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            var httpContext = accessor.HttpContext;

            httpContext?.Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }

}
