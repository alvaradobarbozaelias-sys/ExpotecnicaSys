using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models
{
    public class EvaluacionesM
    {
        [Key]
        public int IdEvaluacion { get; set; }
       
        public required string Categoria { get; set; }

        public required string Proyecto { get; set; }
        
        public required string Evaluador { get; set; }

        public required DateTime Fecha { get; set; }

        public required decimal PuntajeObtenido { get; set; }

        public string? Observaciones { get; set; }

        //// 🔹 Diccionario para almacenar todos los puntajes de la rúbrica
        //public Dictionary<string, int> Rubrica { get; set; } = new Dictionary<string, int>();

        //// 🔹 Puntaje total calculado automáticamente (opcional)
        //public int CalificacionTotal
        //{
        //    get
        //    {
        //        return Rubrica != null ? Rubrica.Values.Sum() : 0;
        //    }
        //}
    }
}