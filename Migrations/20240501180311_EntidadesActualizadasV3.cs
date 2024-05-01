using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class EntidadesActualizadasV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "foto",
                table: "productos",
                newName: "fotoUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fotoUrl",
                table: "productos",
                newName: "foto");
        }
    }
}
