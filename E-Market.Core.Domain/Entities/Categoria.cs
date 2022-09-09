using E_Market.Core.Domain.Commons;
using System.Collections.Generic;

namespace E_Market.Core.Domain.Entities
{
    public class Categoria : AuditableBaseEntity
    { 
        public string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public int CantAnuncios { get; set; }
        public int CantUsuarios { get; set; }
        public List<Anuncio> Anuncios { get; set; }

    }
}
