using E_Market.Core.Application.ViewModels;
using E_Market.Core.Application.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Interfaces.Services
{
    public interface ICategoriaService : IGenericService<SaveCategoriaViewModel,CategoriaViewModel>
    {

    }
}
