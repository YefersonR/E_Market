using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Market.Core.Application.Helpers;

namespace WebApp.Market.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUserService _userService;
        public UsuarioController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);

            }
            UserViewModel userViewModel = await _userService.Login(loginVm);
            if(userViewModel != null)
            {
                HttpContext.Session.Set<UserViewModel>("usuario",userViewModel);
                return RedirectToRoute(new {controller ="Home", action="Index"});
            }
            else
            {
                ModelState.AddModelError("UserValidation", "Usuario o Contraseña incorrectos");
            }
            return View(loginVm);
        }
        public IActionResult Register()
        {
            return View(new SaveUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            await _userService.Add(register);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });

        }
    }
}
