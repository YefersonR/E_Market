using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Anuncio;
using E_Market.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Market.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using E_Market.Core.Application.ViewModels.User;
using E_Market.Core.Application.Interfaces.Repositories;

namespace E_Market.Core.Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        public readonly IAnuncioRepository _anuncioRepository;
        public readonly IUserRepository _userRepository;
        public readonly IImagenRepository _imagenRepository;
        public readonly IHttpContextAccessor _ContextHttp;
        public readonly UserViewModel _userVM;
        public AnuncioService(IAnuncioRepository anuncioRepository,IUserRepository userRepository, IImagenRepository imagenRepository, IHttpContextAccessor ContextHttp)
        {
            _anuncioRepository = anuncioRepository;
            _userRepository = userRepository;
            _imagenRepository = imagenRepository;
            _ContextHttp = ContextHttp;
            _userVM = _ContextHttp.HttpContext.Session.Get<UserViewModel>("usuario");

        }

        public async Task<SaveAnuncioViewModel> Add(SaveAnuncioViewModel vm)
        {
            Anuncio anuncio = new();
            anuncio.Nombre = vm.Nombre;
            anuncio.Precio = vm.Precio;

            //_imagenRepository.AddAsync(vm.);
            anuncio.Descripcion = vm.Descripcion;
            anuncio.CategoriaId = vm.CategoriaId;
            anuncio.UserId = _userVM.Id;

            anuncio = await _anuncioRepository.AddAsync(anuncio);
            SaveAnuncioViewModel anuncioViewModel = new();
            anuncioViewModel.Id = anuncio.Id;
            anuncioViewModel.Nombre = anuncio.Nombre;
            anuncioViewModel.Precio = anuncio.Precio;
            anuncioViewModel.Descripcion = anuncio.Descripcion;
            anuncioViewModel.CategoriaId = anuncio.CategoriaId;
            return anuncioViewModel;
        }

        public async Task Update(SaveAnuncioViewModel vm)
        {
            Anuncio anuncio = await _anuncioRepository.GetByIdAsync(vm.Id);
            anuncio.Id = vm.Id;
            anuncio.Nombre = vm.Nombre;
            anuncio.Precio = vm.Precio;
            anuncio.Descripcion = vm.Descripcion;
            anuncio.CategoriaId = vm.CategoriaId;

            await _anuncioRepository.UpdateAsync(anuncio);
        }

        public async Task Delete(int id)
        {
            var anuncio = await _anuncioRepository.GetByIdAsync(id);
            await _anuncioRepository.DeleteAsync(anuncio);

        }

        public async Task<SaveAnuncioViewModel> GetByIdSaveViewModel(int id)
        {
            var anuncio = await _anuncioRepository.GetByIdAsync(id);
            List<Imagen> imagen = await _imagenRepository.GetAllAsync();
            SaveAnuncioViewModel vm = new();
            vm.Id = anuncio.Id;
            vm.Nombre = anuncio.Nombre;
            vm.Descripcion = anuncio.Descripcion;
            vm.Precio = anuncio.Precio;
            vm.CategoriaId = anuncio.CategoriaId;
            vm.Created = anuncio.Created;
            vm.CreatedBy = anuncio.CreatedBy;
            var user = await _userRepository.GetByIdAsync(anuncio.UserId);
            vm.Telefono = user.Telefono;
            vm.Imagenes = imagen.Where(img => img.IdAnuncio == anuncio.Id).Select(img => img.UrlImg).ToList();

            return vm;
        }
        public async Task<List<AnuncioViewModel>> GetAllUserViewModel()
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            List<Imagen> imagen = await _imagenRepository.GetAllAsync();

            return list.Where(anuncio => anuncio.UserId == _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Precio = anuncio.Precio,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy,
                Imagenes = imagen.Where(img => img.IdAnuncio == anuncio.Id).Select(img => img.UrlImg).ToList()

            }).ToList();
        }
        public async Task<List<AnuncioViewModel>> GetAllViewModel()
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            List<Imagen> imagen = await _imagenRepository.GetAllAsync();
            return list.Where(anuncio => anuncio.UserId != _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy,
                Imagenes = imagen.Where(img => img.IdAnuncio == anuncio.Id).Select(img => img.UrlImg).ToList()



            }).ToList();
        }

        public async Task<List<AnuncioViewModel>> GetAllViewModelWithFilter(FilterAnuncioViewModel filter)
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            List<Imagen> imagen = await _imagenRepository.GetAllAsync();
            var listVM = list.Where(anuncio => anuncio.UserId != _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Precio = anuncio.Precio,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy,
                Imagenes = imagen.Where(img => img.IdAnuncio == anuncio.Id).Select(img => img.UrlImg).ToList()


            })  .ToList();
            if (filter.CategoriaId != null)
            {
                List<AnuncioViewModel> lista = new();
                foreach(int id in filter.CategoriaId)
                {
                    var items = listVM.Where(anuncio => anuncio.CategoriaId == id);
                    foreach (AnuncioViewModel item in items)
                    {
                        lista.Add(item);  
                    }
                }

                listVM = lista.Count() != 0 ? lista : listVM;


            }
            else if(filter.Anuncio != null || filter.Anuncio != "")
            {
                listVM = listVM.Where(anuncio => anuncio.Nombre.ToLower().Contains(filter.Anuncio)).ToList();
            }

            return listVM;
            
        }

    }
}
