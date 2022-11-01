using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.Biblioteca.Infraestructure.Migrations
{
    public partial class LibroUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EditorialId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutorId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "EditorialId",
                table: "Libros");
        }
    }
}
