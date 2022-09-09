using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Market.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddTransient<IAnuncioService, AnuncioService>();
            service.AddTransient<ICategoriaService, CategoriaService>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
