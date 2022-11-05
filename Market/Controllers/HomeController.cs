using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
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

            HomeItemsViewModel homeItem = new HomeItemsViewModel();
            homeItem.Categorias = await _categotiaService.GetAllViewModel();
            homeItem.Anuncios = await _anuncioService.GetAllViewModelWithFilter(filterAnuncio);
            return View(homeItem);
        }
    }
}
