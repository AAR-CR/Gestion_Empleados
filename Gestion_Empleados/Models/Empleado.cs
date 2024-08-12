using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Gestion_Empleados.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Display(Name ="Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public string Puesto { get; set; }
        [Display(Name ="Contratado")]
        public DateTime FechaContratacion { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }

        public virtual ICollection<Nomina> Nominas { get; set; }

        public virtual ICollection<EvaluacionDesempeno> Evaluaciones { get; set; }
        public virtual ICollection<Mensaje> MensajesEnviados { get; set; }
        public virtual ICollection<Correo> CorreosRecibidos { get; set; }

        public Empleado()
        {
            Turnos = new List<Turno>();
            Nominas = new List<Nomina>();
            Evaluaciones = new List<EvaluacionDesempeno>();
            MensajesEnviados = new List<Mensaje>();
            CorreosRecibidos=new List<Correo>();
        }

        public RolUsuario Rol {  get; set; }

        [Display(Name = "Jornada")]
        public int JornadaId { get; set; }

        [Display(Name = "Jornada")]
        public Jornada? Jornada { get; set; }

    }

    public enum RolUsuario
    {
        [EnumMember(Value = "Usuario")]
        Usuario = 0,

        [EnumMember(Value = "Administrador")]
        Administrador = 1
    }
}
