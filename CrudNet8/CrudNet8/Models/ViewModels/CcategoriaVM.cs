using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class CcategoriaVM
    {
        [Required(ErrorMessage = "El campo nombre de categoria es obligatorio.")]
        public required string NombreCategoriaVM { get; set; }

        public string? DescripcionCategoriaVM { get; set; }
    }
}
