using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Market.Middleware;

namespace WebApp.Market.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly UserSession _userSession;
        public CategoriaController(ICategoriaService categoriaService, UserSession userSession)
        {
            _categoriaService = categoriaService;
            _userSession = userSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            var list = await _categoriaService.GetAllViewModel();
            return View(list);
        }
        public IActionResult Create()
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View("SaveCategoria", new SaveCategoriaViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoriaViewModel anuncioViewModel)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveCategoria", anuncioViewModel);
            }

            await _categoriaService.Add(anuncioViewModel);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View("SaveCategoria", await _categoriaService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoriaViewModel saveAnuncioViewModel)  
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveCategoria", saveAnuncioViewModel);
            }

            await _categoriaService.Update(saveAnuncioViewModel);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View(await _categoriaService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            await _categoriaService.Delete(id);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });

        }
    }
}
