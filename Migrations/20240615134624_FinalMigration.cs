using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruequeTools.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
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
                    localidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
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
                    sucursalId = table.Column<int>(type: "int", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
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
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fechaPublicacion = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaPremium = table.Column<DateOnly>(type: "date", nullable: false),
                    isPremium = table.Column<bool>(type: "bit", nullable: false),
                    hasImages = table.Column<bool>(type: "bit", nullable: false),
                    categoriaId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    sucursalId = table.Column<int>(type: "int", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_publicaciones_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "imagenes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.id);
                    table.ForeignKey(
                        name: "FK_imagenes_publicaciones_publicacionId",
                        column: x => x.publicacionId,
                        principalTable: "publicaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ofertas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    publicacionOfertadaId = table.Column<int>(type: "int", nullable: false),
                    publicacionOfrecidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ofertas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ofertas_publicaciones_publicacionOfertadaId",
                        column: x => x.publicacionOfertadaId,
                        principalTable: "publicaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ofertas_publicaciones_publicacionOfrecidaId",
                        column: x => x.publicacionOfrecidaId,
                        principalTable: "publicaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ofertas_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "preguntas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    respuesta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    publicacionId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_preguntas_usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trueques",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<int>(type: "int", nullable: false),
                    hasVentas = table.Column<bool>(type: "bit", nullable: false),
                    cargaCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ofertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trueques", x => x.id);
                    table.ForeignKey(
                        name: "FK_trueques_ofertas_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "ofertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    truequeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_trueques_truequeId",
                        column: x => x.truequeId,
                        principalTable: "trueques",
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
                columns: new[] { "id", "deleted", "direccion", "localidad", "nombre" },
                values: new object[,]
                {
                    { 1, false, "Calle 13 y 38", "La Plata", "Central" },
                    { 2, false, "Calle 66 y 137", "La Plata", "Los Hornos" },
                    { 3, false, "Jorge Bell y Cantilo", "La Plata", "City Bell" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "apellido", "contraseña", "deleted", "email", "fechaNacimiento", "nombre", "rol", "sucursalId" },
                values: new object[,]
                {
                    { 1, "Admin", "admin", false, "admin@admin", new DateOnly(1, 1, 1), "Admin", "Admin", 1 },
                    { 2, "User", "user", false, "user@user", new DateOnly(1, 1, 1), "User", "User", 1 },
                    { 3, "Employee", "employee", false, "employee@employee", new DateOnly(1, 1, 1), "Employee", "Employee", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_publicacionId",
                table: "imagenes",
                column: "publicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ofertas_publicacionOfertadaId",
                table: "ofertas",
                column: "publicacionOfertadaId");

            migrationBuilder.CreateIndex(
                name: "IX_ofertas_publicacionOfrecidaId",
                table: "ofertas",
                column: "publicacionOfrecidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ofertas_usuarioId",
                table: "ofertas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_preguntas_publicacionId",
                table: "preguntas",
                column: "publicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_preguntas_usuarioId",
                table: "preguntas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_truequeId",
                table: "productos",
                column: "truequeId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_categoriaId",
                table: "publicaciones",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_sucursalId",
                table: "publicaciones",
                column: "sucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_publicaciones_usuarioId",
                table: "publicaciones",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_trueques_ofertaId",
                table: "trueques",
                column: "ofertaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_sucursalId",
                table: "usuarios",
                column: "sucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "preguntas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "trueques");

            migrationBuilder.DropTable(
                name: "ofertas");

            migrationBuilder.DropTable(
                name: "publicaciones");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "sucursales");
        }
    }
}
