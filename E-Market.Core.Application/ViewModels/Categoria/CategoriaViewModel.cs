﻿
namespace E_Market.Core.Application.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantAnuncios { get; set; }
        public int CantUsuarios { get; set; }
    }
}
