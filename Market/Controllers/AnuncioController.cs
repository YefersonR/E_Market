using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Anuncio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Market.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoriaService _categoriaService;
        public AnuncioController(IAnuncioService anuncioService, ICategoriaService  categoriaService)
        {
            _anuncioService = anuncioService;
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _anuncioService.GetAllViewModel();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            SaveAnuncioViewModel anuncioViewModel = new SaveAnuncioViewModel();
            anuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
            return View("SaveAnuncio", anuncioViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAnuncioViewModel anuncioViewModel)
        {
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
            SaveAnuncioViewModel anuncioViewModel = await _anuncioService.GetByIdSaveViewModel(id);
            anuncioViewModel.Categorias = await _categoriaService.GetAllViewModel();
            return View("SaveAnuncio", anuncioViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveAnuncioViewModel saveAnuncioViewModel)
        {
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
            return View(await _anuncioService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _anuncioService.Delete(id);
            return RedirectToRoute(new { controller = "Anuncio", action ="Index" });

        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _anuncioService.GetByIdSaveViewModel(id));
        }
    }
}
