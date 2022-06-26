using E_Market.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class Categoria : AuditableBaseEntity
    { 
        public string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public int CantAnuncios { get; set; }
        public List<Anuncio> Anuncios { get; set; }
    }
}
