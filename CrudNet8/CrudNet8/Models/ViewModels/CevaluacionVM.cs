using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models.ViewModels
{
    public class CevaluacionVM
    {
        [Required(ErrorMessage ="Escoger la categoria es obligatorio")]
        public required string CevCategoriaVM { get; set; }

        [Required(ErrorMessage = "Escoger el proyecto es obligatorio")]
        public required string CevProyectoVM { get; set; }

        public required string CevEvaluadorVM { get; set; }

        public required DateTime CevFechaVM { get; set; }

        public required decimal CevPuntajeObtenidoVM { get; set; }

        public string? CevObservacionesVM { get; set; }
    }
}
