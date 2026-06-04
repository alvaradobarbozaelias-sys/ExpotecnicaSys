using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudNet8.Models
{
    public class UsuarioM
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(35)]
        public required string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(int.MaxValue)]
        [DataType(DataType.Password)]
        public required string PasswordHash { get; set; }

        [Required]
        public required bool EstadoUsuario { get; set; }

        // --- FK hacia Rol
        [Required]
        public int IdRol { get; set; }
        [ForeignKey(nameof(IdRol))]
        public RolM Rol { get; set; } = null!;

        // --- FK hacia Persona
        [Required]
        public string Cedula { get; set; } = null!;
        [ForeignKey(nameof(Cedula))]
        public PersonaM Persona { get; set; } = null!;
    }
}
