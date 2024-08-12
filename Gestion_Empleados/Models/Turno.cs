using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.Models
{
    public class Turno
    {
        [Key]
        public int TurnoId { get; set; }

        public int EmpleadoId { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Final { get; set; }

        public string Descripcion { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
