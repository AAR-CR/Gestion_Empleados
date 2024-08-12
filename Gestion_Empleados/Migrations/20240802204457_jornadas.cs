using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Empleados.Migrations
{
    /// <inheritdoc />
    public partial class jornadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JornadaId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    JornadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.JornadaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_JornadaId",
                table: "Empleados",
                column: "JornadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Jornadas_JornadaId",
                table: "Empleados",
                column: "JornadaId",
                principalTable: "Jornadas",
                principalColumn: "JornadaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Jornadas_JornadaId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_JornadaId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "JornadaId",
                table: "Empleados");
        }
    }
}
