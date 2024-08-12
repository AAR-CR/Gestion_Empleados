using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.Models
{
    public class EvaluacionDesempeno
    {
        [Key]
        public int EvaluacionDesempenoId { get; set; }

        public int EmpleadoId { get; set; }

        [Required]
        public DateTime FechaEvaluacion { get; set; }

        public string Objetivos { get; set; }

        public string Retroalimentacion { get; set; }

        public virtual Empleado Empleado { get; set; }

    }
}
