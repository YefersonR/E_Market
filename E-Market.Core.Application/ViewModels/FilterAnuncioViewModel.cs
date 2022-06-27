using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels
{
    public class FilterAnuncioViewModel
    {

        public List<int?> CategoriaId { get; set; }
        public string Anuncio { get; set; } = "";
    }
}
