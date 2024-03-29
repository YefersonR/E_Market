﻿using E_Market.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel,UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel loginViewModel);
    }
}
