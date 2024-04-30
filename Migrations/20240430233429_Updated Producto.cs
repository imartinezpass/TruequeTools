using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Productos",
                newName: "CategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Productos",
                newName: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
