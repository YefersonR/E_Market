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

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoriaService _categotiaService;

        public HomeController(IAnuncioService anuncioService, ICategoriaService categoriaService)
        {
            _anuncioService = anuncioService;
            _categotiaService = categoriaService;
        }

        public async Task<IActionResult> Index(FilterAnuncioViewModel filterAnuncio)
        {

            ViewBag.Categorias = await _categotiaService.GetAllViewModel(); 
            return View(await _anuncioService.GetAllViewModelWithFilter(filterAnuncio));
        }

    }
}
