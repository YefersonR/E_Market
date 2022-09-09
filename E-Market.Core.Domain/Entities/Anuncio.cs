using E_Market.Core.Domain.Commons;

namespace E_Market.Core.Domain.Entities
{
    public class Anuncio : AuditableBaseEntity
    {
        public string  Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int UserId { get; set; }
        public User Usuario{ get; set; }
    }
}
