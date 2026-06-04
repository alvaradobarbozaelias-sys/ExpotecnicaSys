using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class RcategoriaVM
    {
        public int RidCategoriaVM { get; set; }

        public required string RnombreCategoriaVM { get; set; }

        public string? RdescripcionCategoriaVM { get; set; }

        public bool RestadoCategoriaVM { get; set; }
    }
}
