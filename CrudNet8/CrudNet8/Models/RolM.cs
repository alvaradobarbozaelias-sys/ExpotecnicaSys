using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models
{
    public class RolM
    {
        [Key]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        public required string NombreRol { get; set; }

        public string? DescripcionRol { get; set; }

        public required bool EstadoRol { get; set; }
    }
}
