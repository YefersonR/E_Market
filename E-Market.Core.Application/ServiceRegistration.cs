using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IAnuncioService, AnuncioService>();
            service.AddTransient<ICategoriaService, CategoriaService>();
            service.AddTransient<IUserService, UserService>();


        }
    }
}
