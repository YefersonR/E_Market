using E_Market.Core.Application.Interfaces;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Categoria;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Add(SaveCategoriaViewModel vm)
        {
            Categoria categoria = new();
            categoria.Nombre = vm.Nombre;
            categoria.Descripcion = vm.Descripcion;
            

            await _categoriaRepository.AddAsync(categoria);
        }

        public async Task Update(SaveCategoriaViewModel vm)
        {
            Categoria categoria = new();
            categoria.Id = vm.Id;
            categoria.Nombre = vm.Nombre;
            categoria.Descripcion = vm.Descripcion;

            await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task Delete(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            await _categoriaRepository.DeleteAsync(categoria);
        }

        public async Task<SaveCategoriaViewModel> GetByIdSaveViewModel(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            SaveCategoriaViewModel vm = new();
            vm.Id = categoria.Id;
            vm.Nombre = categoria.Nombre;
            vm.Descripcion = categoria.Descripcion;


            return vm;
        }
        public async Task<CategoriaViewModel> GetByIdViewModel(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            CategoriaViewModel vm = new();
            vm.Id = categoria.Id;
            vm.Nombre = categoria.Nombre;
            vm.Descripcion = categoria.Descripcion;


            return vm;
        }

        public async Task<List<CategoriaViewModel>> GetAllViewModel()
        {
            var list = await _categoriaRepository.GetAllWithIncludeAsync(new List<string> { "Anuncios" });
            return list.Select(categoria => new CategoriaViewModel
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                CantAnuncios = categoria.Anuncios.Count()
            }).ToList();
        }


    }
}
