using System.ComponentModel.DataAnnotations;

namespace Gestion_Empleados.Models
{
    public class Nomina
    {
        [Key]
        public int NominaId { get; set; }

        public int EmpleadoId { get; set; }

        [Required]
        public decimal Salario { get; set; }

        public decimal Deducciones { get; set; }

        public decimal Bonos { get; set; }

        [Required]
        public DateTime DiaDePago { get; set; }

        public virtual Empleado Empleado { get; set; }

    }
}
