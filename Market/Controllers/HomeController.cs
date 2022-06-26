using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels;
using E_Market.Core.Domain.Entities;
using Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Market.Middleware;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoriaService _categotiaService;
        private readonly UserSession _userSession;

        public HomeController(IAnuncioService anuncioService, ICategoriaService categoriaService, UserSession userSession)
        {
            _anuncioService = anuncioService;
            _categotiaService = categoriaService;
            _userSession = userSession;
        }

        public async Task<IActionResult> Index(FilterAnuncioViewModel filterAnuncio)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            ViewBag.Categorias = await _categotiaService.GetAllViewModel(); 
            return View(await _anuncioService.GetAllViewModelWithFilter(filterAnuncio));
        }

    }
}
