using E_Market.Core.Application.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels.Anuncio
{
    public class SaveAnuncioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Ingrese un nombre para el anuncio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripcion del anuncio")]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }
        [Required(ErrorMessage = "Debe colocar un precio")]
        public double Precio { get; set; }
        [Range(1, int.MaxValue,ErrorMessage="Debe colocar una categoria validad")]
        public int CategoriaId { get; set; }
        public DateTime Created { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; } 
    }
}
