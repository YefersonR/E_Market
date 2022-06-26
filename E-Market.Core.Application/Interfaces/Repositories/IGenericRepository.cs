using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T type);
        Task UpdateAsync(T type);
        Task DeleteAsync(T type);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithIncludeAsync(List<string> propierties);
        Task<T> GetByIdAsync(int id);
    }
}
