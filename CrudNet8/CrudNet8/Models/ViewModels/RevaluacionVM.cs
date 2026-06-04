using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class RevaluacionVM
    {
        [Key]
        public required int RidEvaluacionVM { get; set; }

        public required string RevCategoriaVM { get; set; }

        public required string RevProyectoVM { get; set; }

        public required string RevEvaluadorVM { get; set; }

        public required DateTime RevFechaVM { get; set; }

        public required decimal RevPuntajeObtenidoVM { get; set; }

        public string? RevObservacionesVM { get; set; }
    }
}
