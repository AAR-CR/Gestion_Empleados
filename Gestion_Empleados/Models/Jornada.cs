using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.Models
{
    public class Jornada
    {
        [Key]
        public int JornadaId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de la Jornada")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Hora de Inicio")]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        [Display(Name = "Hora de Fin")]
        public TimeSpan HoraFin { get; set; }
    }
}
