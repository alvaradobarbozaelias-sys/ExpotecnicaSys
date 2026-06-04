using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public required string Usernamein { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public required string Passwordin { get; set; }
    }
}