using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Empleados.Models
{
    public class Mensaje
    {
        [Key]
        public int MensajeId { get; set; }
        [Required]
        [Display(Name = "Remitente")]
        public int RemitenteId { get; set; }

        [ForeignKey("RemitenteId")]
        public virtual Empleado Remitente { get; set; }

        [Required]
        [StringLength(100)]
        public string Asunto { get; set; }
        [Required]
        [Display(Name = "Mensaje")]
        public string Texto { get; set; }

        [Display(Name = "Fecha de Envío")]
        public DateTime Fecha { get; set; } = DateTime.Now;


    }
}
