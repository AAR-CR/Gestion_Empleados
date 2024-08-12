using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.Models
{
    public class Correo
    {

        [Key]
        public int CorreoId { get; set; }
        [Required]
        [Display(Name = "Remitente")]
        public int RemitenteId { get; set; }

        [ForeignKey("RemitenteId")]
        public virtual Empleado Remitente { get; set; }

        [Display(Name = "Destinatario")]
        public int? DestinatarioId { get; set; }

        [ForeignKey("DestinatarioId")]
        public virtual Empleado Destinatario { get; set; }

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
