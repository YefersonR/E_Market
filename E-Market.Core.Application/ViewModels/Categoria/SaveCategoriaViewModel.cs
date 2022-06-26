using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels.Categoria
{
    public class SaveCategoriaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe colocar un nombre a la categoria")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe colocar una descripcion de la categoria")]
        public string Descripcion { get; set; }
        public int CantAnuncios { get; set; }
    }
}
