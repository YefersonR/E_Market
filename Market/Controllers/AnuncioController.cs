using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Anuncio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Market.Middleware;

namespace WebApp.Market.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoriaService _categoriaService;
        private readonly UserSession _userSession;
        public AnuncioController(IAnuncioService anuncioService, ICategoriaService  categoriaService,UserSession userSession)
        {
            _anuncioService = anuncioService;
            _categoriaService = categoriaService;
            _userSession = userSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_userSession.hasUser())
            {
                var list = await _anuncioService.GetAllUserViewModel();
                return View(list);
            }
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }
        public async Task<IActionResult> Create()
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            SaveAnuncioViewModel anuncioViewModel = new SaveAnuncioViewModel();
            anuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
            return View("SaveAnuncio", anuncioViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAnuncioViewModel anuncioViewModel)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                anuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
                return View("SaveAnuncio", anuncioViewModel);
            }

            await _anuncioService.Add(anuncioViewModel);
            return RedirectToRoute(new { controller = "Anuncio", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            SaveAnuncioViewModel anuncioViewModel = await _anuncioService.GetByIdSaveViewModel(id);
            anuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
            return View("SaveAnuncio", anuncioViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveAnuncioViewModel saveAnuncioViewModel)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                saveAnuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
                return View("SaveAnuncio", saveAnuncioViewModel);
            }

            await _anuncioService.Update(saveAnuncioViewModel);
            return RedirectToRoute(new { controller = "Anuncio", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View(await _anuncioService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            await _anuncioService.Delete(id);
            return RedirectToRoute(new { controller = "Anuncio", action ="Index" });

        }
        public async Task<IActionResult> Detail(int id)
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View(await _anuncioService.GetByIdSaveViewModel(id));
        }
    }
}
