using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class EntidadesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comentario",
                table: "ofertas",
                newName: "productoNombre");

            migrationBuilder.AddColumn<string>(
                name: "productoDescripcion",
                table: "ofertas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productoFotoUrl",
                table: "ofertas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productoDescripcion",
                table: "ofertas");

            migrationBuilder.DropColumn(
                name: "productoFotoUrl",
                table: "ofertas");

            migrationBuilder.RenameColumn(
                name: "productoNombre",
                table: "ofertas",
                newName: "comentario");
        }
    }
}
