using System.Collections.Generic;

namespace E_Market.Core.Application.ViewModels
{
    public class FilterAnuncioViewModel
    {
        public List<int?> CategoriaId { get; set; }
        public string Anuncio { get; set; } = "";
    }
}
