using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Domain.Entities;
using E_Market.Infrastructure.Persistence.Contexts;

namespace E_Market.Infrastructure.Persistence.Repositories
{
    public class AnuncioRepository : GenericRepository<Anuncio>,IAnuncioRepository 
    {
        private readonly E_MarketContext _marketContext;
        public AnuncioRepository(E_MarketContext marketContext):base(marketContext)
        {
            _marketContext = marketContext;
        }
    }
}
