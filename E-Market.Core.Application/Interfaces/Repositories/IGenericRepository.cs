using System.Threading.Tasks;
using System.Collections.Generic;

namespace E_Market.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T type);
        Task UpdateAsync(T type);
        Task DeleteAsync(T type);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithIncludeAsync(List<string> propierties);
        Task<T> GetByIdAsync(int id);
    }
}
