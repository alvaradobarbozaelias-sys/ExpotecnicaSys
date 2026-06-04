using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CrudNet8.Models
{
    public class ContactoM
    {

        [Key]
        public int CedulaID { get; set; }

        [Required (ErrorMessage ="El campo nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required (ErrorMessage ="El campo Apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required (ErrorMessage ="El campo Email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage ="El campo Teléfono es obligatori")]
        public string Telefono { get; set; }

        
        public DateTime FechaInscripcion { get; set; }



    }

}
