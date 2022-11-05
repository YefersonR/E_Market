using E_Market.Core.Application.ViewModels.Imagen;
using E_Market.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface IImagenService
    {
        Task<SaveImagenViewModel> Add(SaveImagenViewModel type);
        Task Update(SaveImagenViewModel type);
        Task Delete(int id);
        Task<List<SaveImagenViewModel>> GetImages(int id);
    }
}
