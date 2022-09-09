using System.ComponentModel.DataAnnotations;

namespace E_Market.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe colocar el nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Debe colocar su nombre del usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Coloque su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare(nameof(Password),ErrorMessage ="Las contraseñas no coinciden")]
        [Required(ErrorMessage = "Coloque su contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Debe colocar su direccion de correo")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Debe colocar su numero de telefono")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
    }
}
