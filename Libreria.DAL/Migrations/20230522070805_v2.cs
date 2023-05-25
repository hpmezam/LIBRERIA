using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Autores_AutorId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_AutorId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Autores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Autores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_AutorId",
                table: "Autores",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Autores_AutorId",
                table: "Autores",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");
        }
    }
}
