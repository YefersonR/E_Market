﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IGenericService<T, Vm> where T : class
    {
        Task<T> Add(T type);
        Task Update(T type);
        Task Delete(int id);
        Task<T> GetByIdSaveViewModel(int id);
        Task<List<Vm>> GetAllViewModel();
    }
}
