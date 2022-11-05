using E_Market.Core.Domain.Commons;
using System.Collections.Generic;

namespace E_Market.Core.Domain.Entities
{
    public class Anuncio : AuditableBaseEntity
    {
        public string  Nombre { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Imagen> Imagenes { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int UserId { get; set; }
        public User Usuario{ get; set; }
    }
}
