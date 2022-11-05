
using E_Market.Core.Domain.Commons;
using System.Collections.Generic;

namespace E_Market.Core.Domain.Entities
{
    public class Imagen : AuditableBaseEntity
    {
        public string UrlImg { get; set; }
        public int IdAnuncio { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}
