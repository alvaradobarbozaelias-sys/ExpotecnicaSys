using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class UcategoriaVM
    {
        [Required(ErrorMessage="El id de la categoria es obligatoria")]
        public int UidCategoriaVM { get; set; }

        public required string UnombreCategoriaVM { get; set; }

        public string? UdescripcionCategoriaVM { get; set; }

        public bool UestadoCategoriaVM { get; set; }
    }
}
