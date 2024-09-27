using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsitenciaUNC_attemp_2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_AspNetUsers_IdUsuario",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Eventos_IdEvento",
                table: "Registros");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_AspNetUsers_IdUsuario",
                table: "Registros",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Eventos_IdEvento",
                table: "Registros",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_AspNetUsers_IdUsuario",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Eventos_IdEvento",
                table: "Registros");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_AspNetUsers_IdUsuario",
                table: "Registros",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Eventos_IdEvento",
                table: "Registros",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
