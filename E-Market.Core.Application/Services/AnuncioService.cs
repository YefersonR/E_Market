using E_Market.Core.Application.Interfaces;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Anuncio;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Market.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using E_Market.Core.Application.ViewModels.User;


namespace E_Market.Core.Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        public readonly IAnuncioRepository _anuncioRepository;
        public readonly IHttpContextAccessor _ContextHttp;
        public readonly UserViewModel _userVM;
        public AnuncioService(IAnuncioRepository anuncioRepository, IHttpContextAccessor ContextHttp)
        {
            _anuncioRepository = anuncioRepository;
            _ContextHttp = ContextHttp;
            _userVM = _ContextHttp.HttpContext.Session.Get<UserViewModel>("usuario");

        }

        public async Task<SaveAnuncioViewModel> Add(SaveAnuncioViewModel vm)
        {
            Anuncio anuncio = new();
            anuncio.Nombre = vm.Nombre;
            anuncio.Precio = vm.Precio;
            anuncio.Imagen = vm.Imagen;
            anuncio.Descripcion = vm.Descripcion;
            anuncio.CategoriaId = vm.CategoriaId;
            anuncio.UserId = _userVM.Id;

            anuncio = await _anuncioRepository.AddAsync(anuncio);
            SaveAnuncioViewModel anuncioViewModel = new();
            anuncioViewModel.Id = anuncio.Id;
            anuncioViewModel.Nombre = anuncio.Nombre;
            anuncioViewModel.Precio = anuncio.Precio;
            anuncioViewModel.Imagen = anuncio.Imagen;
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
            anuncio.Imagen = vm.Imagen;
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
            SaveAnuncioViewModel vm = new();
            vm.Id = anuncio.Id;
            vm.Nombre = anuncio.Nombre;
            vm.Descripcion = anuncio.Descripcion;
            vm.Precio = anuncio.Precio;
            vm.Imagen = anuncio.Imagen;
            vm.CategoriaId = anuncio.CategoriaId;
            vm.Created = anuncio.Created;
            vm.CreatedBy = anuncio.CreatedBy;

            return vm;
        }
        public async Task<List<AnuncioViewModel>> GetAllUserViewModel()
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            return list.Where(anuncio => anuncio.UserId == _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Precio = anuncio.Precio,
                Imagen = anuncio.Imagen,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy

            }).ToList();
        }
        public async Task<List<AnuncioViewModel>> GetAllViewModel()
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            return list.Where(anuncio => anuncio.UserId != _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Precio = anuncio.Precio,
                Imagen = anuncio.Imagen,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy


            }).ToList();
        }

        public async Task<List<AnuncioViewModel>> GetAllViewModelWithFilter(FilterAnuncioViewModel filter)
        {
            var list = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "Categoria" });
            var listVM = list.Where(anuncio => anuncio.UserId != _userVM.Id).Select(anuncio => new AnuncioViewModel
            {
                Id = anuncio.Id,
                Nombre = anuncio.Nombre,
                Descripcion = anuncio.Descripcion,
                Precio = anuncio.Precio,
                Imagen = anuncio.Imagen,
                Categoria = anuncio.Categoria.Nombre,
                CategoriaId = anuncio.Categoria.Id,
                Created = anuncio.Created,
                CreatedBy = anuncio.CreatedBy


            })  .ToList();
            if (filter.CategoriaId != null)
            {
                List<AnuncioViewModel> lista = new();
                foreach(int id in filter.CategoriaId)
                {
                   
                    lista.Add(listVM.FirstOrDefault(anuncio => anuncio.CategoriaId == id));
                   
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
