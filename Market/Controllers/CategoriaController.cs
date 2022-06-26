using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Market.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _categoriaService.GetAllViewModel();
            return View(list);
        }
        public IActionResult Create()
        {
            return View("SaveCategoria", new SaveCategoriaViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoriaViewModel anuncioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveCategoria", anuncioViewModel);
            }

            await _categoriaService.Add(anuncioViewModel);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveCategoria", await _categoriaService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoriaViewModel saveAnuncioViewModel)  
        {
            if (!ModelState.IsValid)
            {
                return View("SaveCategoria", saveAnuncioViewModel);
            }

            await _categoriaService.Update(saveAnuncioViewModel);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            
            return View(await _categoriaService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _categoriaService.Delete(id);
            return RedirectToRoute(new { controller = "Categoria", action = "Index" });

        }
    }
}
