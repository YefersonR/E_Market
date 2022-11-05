using E_Market.Core.Application.ViewModels.Anuncio;
using E_Market.Core.Application.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels.Home
{
    public class HomeItemsViewModel
    {
        public List<CategoriaViewModel> Categorias { get; set;}
        public List<AnuncioViewModel> Anuncios { get; set; }
    }
}
