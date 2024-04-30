using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class ProductosComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Publicaciones");

            migrationBuilder.RenameColumn(
                name: "PropietarioId",
                table: "Publicaciones",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Publicaciones",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Publicaciones",
                newName: "ComentarioId");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Publicaciones",
                newName: "ProductoId");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Publicaciones",
                newName: "PropietarioId");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Publicaciones",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Publicaciones",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "ComentarioId",
                table: "Publicaciones",
                newName: "Descripcion");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Publicaciones",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
