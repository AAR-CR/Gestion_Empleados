﻿// <auto-generated />
using System;
using Gestion_Empleados.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestion_Empleados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240812203831_actualizarfinal")]
    partial class actualizarfinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gestion_Empleados.Models.Correo", b =>
                {
                    b.Property<int>("CorreoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CorreoId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("DestinatarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemitenteId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorreoId");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("RemitenteId");

                    b.ToTable("Correos");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("JornadaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("JornadaId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.EvaluacionDesempeno", b =>
                {
                    b.Property<int>("EvaluacionDesempenoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluacionDesempenoId"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEvaluacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Objetivos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Retroalimentacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvaluacionDesempenoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("EvaluacionesDesempeno");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Jornada", b =>
                {
                    b.Property<int>("JornadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JornadaId"));

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("JornadaId");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Mensaje", b =>
                {
                    b.Property<int>("MensajeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MensajeId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemitenteId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MensajeId");

                    b.HasIndex("RemitenteId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Nomina", b =>
                {
                    b.Property<int>("NominaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NominaId"));

                    b.Property<decimal>("Bonos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Deducciones")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DiaDePago")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NominaId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Nominas");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurnoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("TurnoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Correo", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Empleado", "Destinatario")
                        .WithMany("CorreosRecibidos")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gestion_Empleados.Models.Empleado", "Remitente")
                        .WithMany()
                        .HasForeignKey("RemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Remitente");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Empleado", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Jornada", "Jornada")
                        .WithMany()
                        .HasForeignKey("JornadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jornada");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.EvaluacionDesempeno", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Empleado", "Empleado")
                        .WithMany("Evaluaciones")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Mensaje", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Empleado", "Remitente")
                        .WithMany("MensajesEnviados")
                        .HasForeignKey("RemitenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Remitente");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Nomina", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Empleado", "Empleado")
                        .WithMany("Nominas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Turno", b =>
                {
                    b.HasOne("Gestion_Empleados.Models.Empleado", "Empleado")
                        .WithMany("Turnos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Gestion_Empleados.Models.Empleado", b =>
                {
                    b.Navigation("CorreosRecibidos");

                    b.Navigation("Evaluaciones");

                    b.Navigation("MensajesEnviados");

                    b.Navigation("Nominas");

                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}
