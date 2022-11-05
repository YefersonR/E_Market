using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.Imagen;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class ImagenService : IImagenService
    {
        private readonly IImagenRepository _imagenRepository;
        public ImagenService(IImagenRepository imagenRepository)
        {
            _imagenRepository = imagenRepository;
        }
        public async Task<SaveImagenViewModel> Add(SaveImagenViewModel type)
        {
            Imagen imagen = new();
            imagen.UrlImg = type.UrlImg;
            imagen.IdAnuncio = type.IdAnuncio;
            imagen = await _imagenRepository.AddAsync(imagen);
            SaveImagenViewModel imagenViewModel = new();
            imagenViewModel.IdAnuncio = imagen.IdAnuncio;
            imagenViewModel.UrlImg = imagen.UrlImg;

            return imagenViewModel;
        }
        public async Task<List<SaveImagenViewModel>> GetImages(int id)
        {
            var images = await _imagenRepository.GetAllAsync();
            return images.Where(img => img.IdAnuncio == id).Select(img => new SaveImagenViewModel 
            {
                Id = img.Id,
                IdAnuncio = img.IdAnuncio,
                UrlImg= img.UrlImg
            }).ToList();
        }



        public async Task Delete(int id)
        {
            List<Imagen> imagen = await _imagenRepository.GetAllAsync();
            imagen = imagen.Where(anuncioImg=>anuncioImg.IdAnuncio == id).ToList();
            foreach (Imagen img in imagen)
            {
                await _imagenRepository.DeleteAsync(img);
            }
        }

        public async Task Update(SaveImagenViewModel type)
        {
            Imagen imagen = await _imagenRepository.GetByIdAsync(type.Id);
            imagen.Id = type.Id;
            imagen.UrlImg = type.UrlImg;

            await _imagenRepository.UpdateAsync(imagen);
        }
    }
}
