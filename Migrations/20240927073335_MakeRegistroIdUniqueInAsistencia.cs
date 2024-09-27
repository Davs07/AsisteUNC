using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsitenciaUNC_attemp_2.Migrations
{
    /// <inheritdoc />
    public partial class MakeRegistroIdUniqueInAsistencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Asistencias_RegistroId",
                table: "Asistencias");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_RegistroId",
                table: "Asistencias",
                column: "RegistroId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Asistencias_RegistroId",
                table: "Asistencias");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_RegistroId",
                table: "Asistencias",
                column: "RegistroId");
        }
    }
}
