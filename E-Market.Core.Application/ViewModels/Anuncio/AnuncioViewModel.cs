using E_Market.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels.Anuncio
{
    public class AnuncioViewModel : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
        public string  Categoria { get; set; }
        public int CategoriaId { get; set; }


    }
}
