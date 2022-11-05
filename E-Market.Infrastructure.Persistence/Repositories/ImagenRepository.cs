using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Core.Domain.Entities;
using E_Market.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Market.Infrastructure.Persistence.Repositories
{
    public class ImagenRepository : GenericRepository<Imagen>, IImagenRepository
    {
        public readonly E_MarketContext _MarketContext;
        public ImagenRepository(E_MarketContext MarketContext) : base(MarketContext)
        {
            _MarketContext = MarketContext;
        }
    }
}
