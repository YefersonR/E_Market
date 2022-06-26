using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Anuncio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IAnuncioService : IGenericService<SaveAnuncioViewModel,AnuncioViewModel>
    {
        Task<List<AnuncioViewModel>> GetAllViewModelWithFilter(FilterAnuncioViewModel filter);
    }
}
