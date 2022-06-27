using E_Market.Core.Application.Interfaces;
using E_Market.Core.Application.Interfaces.Repositories;
using E_Market.Infrastructure.Persistence.Contexts;
using E_Market.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            if(configuration.GetValue<bool>("DatabaseInMemory"))
            {
                service.AddDbContext<E_MarketContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
            }
            else
            {
                service.AddDbContext<E_MarketContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MarketConnection"), m => m.MigrationsAssembly(typeof(E_MarketContext).Assembly.FullName)));
            }

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IAnuncioRepository, AnuncioRepository>();
            service.AddTransient<ICategoriaRepository, CategoriaRepository>();
            service.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
