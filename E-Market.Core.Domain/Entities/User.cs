using E_Market.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Nombre{ get; set; }
        public string UserName{ get; set; }
        public string Password { get; set; }
        public string  Email { get; set; }
        public string Telefono { get; set; }
        public int AnuncioId { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }
    }
}
