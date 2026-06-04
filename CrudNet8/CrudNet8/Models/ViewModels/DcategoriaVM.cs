using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class DcategoriaVM
    {
        [Required(ErrorMessage="El id de la categoria es obligatoria")]
        public int DidCategoriaVM { get; set; }

        public bool DestadoCategoriaVM { get; set; }
    }
}
