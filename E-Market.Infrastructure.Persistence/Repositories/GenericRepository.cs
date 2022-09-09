using E_Market.Core.Application.Interfaces;
using E_Market.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Market.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly E_MarketContext _marketContext;

        public GenericRepository(E_MarketContext marketContext)
        {
            _marketContext = marketContext;
        }
        public virtual async Task<T> AddAsync(T type)
        {
            await _marketContext.Set<T>().AddAsync(type);
            await _marketContext.SaveChangesAsync();
            return type;
        }

        public virtual async Task UpdateAsync(T type)
        {
            _marketContext.Entry(type).State = EntityState.Modified;
            await _marketContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T type)
        {
            _marketContext.Set<T>().Remove(type);
            await _marketContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _marketContext.Set<T>().ToListAsync();
        }
        public virtual async Task<List<T>> GetAllWithIncludeAsync(List<string> propierties)
        {
            var query =  _marketContext.Set<T>().AsQueryable();
            foreach(string propierty in propierties)
            {
                query = query.Include(propierty);
            }
            return await query.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
             return await _marketContext.Set<T>().FindAsync(id);
        }
    }
}
