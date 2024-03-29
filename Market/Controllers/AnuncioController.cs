﻿using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Anuncio;
using E_Market.Core.Application.ViewModels.Imagen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp.Market.Middleware;

namespace WebApp.Market.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoriaService _categoriaService;
        private readonly IImagenService _imagenService;
        private readonly UserSession _userSession;
        public AnuncioController(IAnuncioService anuncioService, ICategoriaService  categoriaService, IImagenService imagenService, UserSession userSession)
        {
            _anuncioService = anuncioService;
            _categoriaService = categoriaService;
            _imagenService = imagenService;
            _userSession = userSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_userSession.hasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
                var list = await _anuncioService.GetAllUserViewModel();
                return View(list);
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

            SaveAnuncioViewModel anuncioViewModel1 =  await _anuncioService.Add(anuncioViewModel);
            foreach(IFormFile anuncio in anuncioViewModel.Files)
            {
                SaveImagenViewModel saveImagen = new();
                saveImagen.UrlImg = UploadFile(anuncio,anuncioViewModel1.Id);
                saveImagen.IdAnuncio = anuncioViewModel1.Id;
                await _imagenService.Add(saveImagen);
            }

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
            SaveAnuncioViewModel anuncioViewModel = await _anuncioService.GetByIdSaveViewModel(saveAnuncioViewModel.Id);
            if(saveAnuncioViewModel.Files != null)
            {
                string basePath = $"/Img/Anuncios/${anuncioViewModel.Id}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
                await _imagenService.Delete(anuncioViewModel.Id);
                if (Directory.Exists(path))
                {
                    DirectoryInfo directoryInfo = new(path);
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }

                foreach (IFormFile anuncio in saveAnuncioViewModel.Files)
                {
                    SaveImagenViewModel saveImagen = new();
                    if(UploadFile(anuncio, anuncioViewModel.Id, true) != "")
                    {
                        saveImagen.UrlImg = UploadFile(anuncio, anuncioViewModel.Id, true);
                        saveImagen.IdAnuncio = anuncioViewModel.Id;
                        await _imagenService.Add(saveImagen);
                    }
                }
            }
            //saveAnuncioViewModel.Imagen = UploadFile(saveAnuncioViewModel.File,anuncioViewModel.Id,true,anuncioViewModel.Imagen);
            //saveAnuncioViewModel.Imagen1 = UploadFile(saveAnuncioViewModel.File1,anuncioViewModel.Id,true,anuncioViewModel.Imagen1);
            //saveAnuncioViewModel.Imagen2 = UploadFile(saveAnuncioViewModel.File2, anuncioViewModel.Id, true, anuncioViewModel.Imagen2);
            //saveAnuncioViewModel.Imagen3 = UploadFile(saveAnuncioViewModel.File3, anuncioViewModel.Id, true, anuncioViewModel.Imagen3);

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
            string basePath = $"/Img/Anuncios/${id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new(path);
                foreach(FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }
                Directory.Delete(path);
            }

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
        private string UploadFile(IFormFile File, int id, bool IsEditMode = false, string imgUrl = "")
        {
            if (IsEditMode && File == null)
            {
                return imgUrl;
            }
            string basePath = $"/Img/Anuncios/${id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Guid guid = Guid.NewGuid();
            if(File != null)
            {
                FileInfo fileInfo = new(File.FileName);
                string filename = guid + fileInfo.Extension;
                string finalPath = Path.Combine(path, filename);
             

                if (IsEditMode)
                {
                    
                        string[] oldPart = imgUrl.Split("/");
                        string oldImageName = oldPart[^1];
                        string completeOldPath = Path.Combine(path, oldImageName);
                        if (System.IO.File.Exists(completeOldPath))
                        {
                            System.IO.File.Delete(completeOldPath);
                        }
                }
                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }

                return $"{basePath}/{filename}";
            }
            else
            {
                return imgUrl;
            }
        }
    }
}
