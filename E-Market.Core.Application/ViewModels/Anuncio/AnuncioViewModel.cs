using E_Market.Core.Domain.Commons;
using System.Collections.Generic;

namespace E_Market.Core.Application.ViewModels.Anuncio
{
    public class AnuncioViewModel : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<string> Imagenes { get; set; }
        public double Precio { get; set; }
        public string  Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string Telefono { get; set; }


    }
}
