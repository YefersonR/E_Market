using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe colocar el nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="Las contraseñas deben se iguales")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Debe colocar el email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe colocar un telefono")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
    }
}
