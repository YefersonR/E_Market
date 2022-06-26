using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModels.User;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(SaveUserViewModel vm)
        {
            User user = new();
            user.Nombre = vm.Nombre;
            user.UserName = vm.UserName;
            user.Password = vm.Password;
            user.Email = vm.Email;
            user.Telefono = vm.Telefono;

            await _userRepository.AddAsync(user);
        }
        public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            User user = await _userRepository.LoginAsync(loginViewModel);
            if (user == null)
            {
                return null;
            }

            UserViewModel userViewModel = new();
            userViewModel.Id = user.Id;
            userViewModel.Nombre = user.Nombre;
            userViewModel.UserName = user.UserName;
            userViewModel.Password = user.Password;
            userViewModel.Email = user.Email;
            userViewModel.Telefono = user.Telefono;

            return userViewModel;
        }
        public async Task Update(SaveUserViewModel vm)
        {
            User user= new();
            user.Id = vm.Id;
            user.Nombre = vm.Nombre;
            user.UserName = vm.UserName;
            user.Password = vm.Password;
            user.Email = vm.Email;
            user.Telefono = vm.Telefono;

            await _userRepository.UpdateAsync(user);
        }

        public async Task Delete(int id)
        {
            var anuncio = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(anuncio);
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            SaveUserViewModel vm = new();
            vm.Id = user.Id;
            vm.Nombre = user.Nombre;
            vm.UserName = user.UserName;
            vm.Password = user.Password;
            vm.Email = user.Email;
            vm.Telefono = user.Telefono;

            return vm;
        }
        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var list = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Anuncios" });
            return list.Select(user => new UserViewModel
            {
                Id = user.Id,
                Nombre = user.Nombre,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Telefono = user.Telefono,
                


            }).ToList();
        }


    }
}
