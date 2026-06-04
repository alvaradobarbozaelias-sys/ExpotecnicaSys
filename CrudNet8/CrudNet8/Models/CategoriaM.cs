using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudNet8.Models
{
    public class CategoriaM
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo nombre de categoria es obligatorio.")]
        public required string NombreCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public bool EstadoCategoria { get; set; }
    }
}
