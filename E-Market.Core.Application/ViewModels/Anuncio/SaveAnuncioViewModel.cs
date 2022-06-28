using E_Market.Core.Application.ViewModels.Categoria;
using E_Market.Core.Domain.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Market.Core.Application.ViewModels.Anuncio
{
    public class SaveAnuncioViewModel : AuditableBaseEntity
    {
        [Required(ErrorMessage="Ingrese un nombre para el anuncio")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripcion del anuncio")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        [Required(ErrorMessage = "Debe colocar un precio")]
        [DataType(DataType.Currency)]
        public double Precio { get; set; }
        [Range(1, int.MaxValue,ErrorMessage="Debe colocar una categoria validad")]
        public int CategoriaId { get; set; }
        public string Telefono { get; set; }

        public List<CategoriaViewModel> Categorias { get; set; } 
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File1 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File2 { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File3 { get; set; }
    }
}
