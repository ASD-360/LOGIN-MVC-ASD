using System.ComponentModel.DataAnnotations;

namespace LOGIN_MVC_ASD.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El noombre del usuario es obligatorio")]
        [Display(Name = "Nombre del Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
