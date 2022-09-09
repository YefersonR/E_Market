using E_Market.Core.Application.Interfaces;
using E_Market.Core.Domain.Entities;
using E_Market.Infrastructure.Persistence.Contexts;

namespace E_Market.Infrastructure.Persistence.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>,ICategoriaRepository
    {
        private readonly E_MarketContext _marketContext;
        public CategoriaRepository(E_MarketContext marketContext):base(marketContext)
        {
            _marketContext = marketContext;
        }
    }
}
