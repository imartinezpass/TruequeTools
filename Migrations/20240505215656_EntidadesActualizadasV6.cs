using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class EntidadesActualizadasV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sucursales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    localidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sucursales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sucursalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_sucursales_sucursalId",
                        column: x => x.sucursalId,
                        principalTable: "sucursales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "publicaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isPremium = table.Column<bool>(type: "bit", nullable: false),
                    isOculta = table.Column<bool>(type: "bit", nullable: false),
                    fechaPublicacion = table.Column<DateOnly>(type: "date", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    sucursalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_publicaciones_sucursales_sucursalId",
                        column: x => x.sucursalId,
                        principalTable: "sucursales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_publicaciones_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preguntas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    respuesta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    publicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preguntas", x => x.id);
                    table.ForeignKey(
                        name: "FK_preguntas_publicaciones_publicacionId",
                        column: x => x.publicacionId,
                        principalTable: "publicaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fotoUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    categoriaId = table.Column<int>(type: "int", nullable: false),
                    publicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_publicaciones_publicacionId",
                        column: x => x.publicacionId,
                        principalTable: "publicaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "$0 a $5.000" },
                    { 2, "$5.000 a $10.000" },
                    { 3, "Mas de $10.000" }
                });

            migrationBuilder.InsertData(
                table: "sucursales",
                columns: new[] { "id", "direccion", "localidad", "nombre" },
                values: new object[] { 1, "Calle 13 2500", "La Plata", "Central" });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "apellido", "contraseña", "email", "fechaNacimiento", "nombre", "rol", "sucursalId" },
                values: new object[] { 1, "Admin", "admin", "admin@admin", new DateOnly(1, 1, 1), "Admin", "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_preguntas_publicacionId",
                table: "preguntas",
                column: "publicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_categoriaId",
                table: "productos",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_publicacionId",
                table: "productos",
                column: "publicacionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_sucursalId",
                table: "publicaciones",
                column: "sucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_usuarioId",
                table: "publicaciones",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_sucursalId",
                table: "usuarios",
                column: "sucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "preguntas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "sucursales");
        }
    }
}
