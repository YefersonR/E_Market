using E_Market.Core.Application.Interfaces;
using E_Market.Core.Domain.Entities;
using E_Market.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
