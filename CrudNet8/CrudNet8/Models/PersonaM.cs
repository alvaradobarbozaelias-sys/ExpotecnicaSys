using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models
{
    public class PersonaM
    {
        [Key]
        public required string Cedula { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        public required string Nombre1 { get; set; }

        [Required(ErrorMessage = "El segundo nombre es obligatorio.")]
        public required string Nombre2 { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public required string Ap1 { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio.")]
        public required string Ap2 { get; set; }

        public required string Sexo { get; set; }

        [Required(ErrorMessage = "Seleccione su fecha de nacimiento.")]
        public required DateTime FechaNacimiento { get; set; }
    }
}
