using E_Market.Core.Domain.Commons;

namespace E_Market.Core.Application.ViewModels.Anuncio
{
    public class AnuncioViewModel : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public double Precio { get; set; }
        public string  Categoria { get; set; }
        public int CategoriaId { get; set; }



    }
}
