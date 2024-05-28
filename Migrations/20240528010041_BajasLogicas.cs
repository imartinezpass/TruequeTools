using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class BajasLogicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "publicaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2,
                column: "deleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "publicaciones");
        }
    }
}
