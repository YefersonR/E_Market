using System.ComponentModel.DataAnnotations;

namespace E_Market.Core.Application.ViewModels.User
{
    public class LoginViewModel
    { 
        [Required(ErrorMessage = "Ingrese su nombre de usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
