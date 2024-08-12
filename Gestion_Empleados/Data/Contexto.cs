using Gestion_Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Empleados.Data
{
    public class Contexto:DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<EvaluacionDesempeno> EvaluacionesDesempeno { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Correo> Correos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación entre Empleado y Jornada
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Jornada)
                .WithMany()
                .HasForeignKey(e => e.JornadaId);

            modelBuilder.Entity<Mensaje>()
           .HasOne(m => m.Remitente)
           .WithMany(e => e.MensajesEnviados)
           .HasForeignKey(m => m.RemitenteId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Correo>()
            .HasOne(c => c.Destinatario)
            .WithMany(e => e.CorreosRecibidos)
            .HasForeignKey(c => c.DestinatarioId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
