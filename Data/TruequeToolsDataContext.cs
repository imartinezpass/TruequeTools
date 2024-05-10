using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TruequeTools.Entities;

/*
 
Esta clase establece el contexto de la base de datos SQL usando MicrosoftEntityFrameworkCore
Todo lo que se modifique aca afecta la estructura de la base de datos SQL

Si se agregan DbSet nuevos primero se debe crear una nueva migracion con: Add-Migration "nombre_de_la_migracion"
Luego se debe actualizar la base de datos con: Update-Database
 
 */

namespace TruequeTools.Data
{
    public class TruequeToolsDataContext(DbContextOptions<TruequeToolsDataContext> options) : DbContext(options)
	{

        //VINCULO ENTRE LA BASE DE DATOS Y LAS ENTIDADES
        public DbSet<Categoria> Categorias { get; set; } 
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //VINCULO ENTRE LA BASE DE DATOS Y LAS ENTIDADES

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Usuario y Sucursal
            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Sucursal)  // Un usuario pertenece a una única sucursal
                .WithMany()  // No especificamos WithOne() ya que la relación es uno a uno o muchos a uno
                .HasForeignKey(x => x.SucursalId)  // Clave externa en la tabla Usuarios que referencia la tabla Sucursales
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION)

            // Configuración de la relación entre Usuario y Publicaciones
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Publicaciones) // Un usuario puede tener muchas publicaciones
                .WithOne(x => x.Usuario) // Cada publicación pertenece a un único usuario
                .HasForeignKey(x => x.UsuarioId); // Clave externa en la tabla Publicaciones

            // Configuración de la relación entre Publicación y Sucursal
            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Sucursal)  // Una publicación pertenece a una única sucursal
                .WithMany()  // No especificamos WithOne() ya que la relación es uno a uno o muchos a uno
                .HasForeignKey(x => x.SucursalId)  // Clave externa en la tabla Publicaciones que referencia la tabla Sucursales
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION)

            // Configuración de la relación entre Publicación y Usuario
            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Usuario)  // Una publicación pertenece a un único usuario
                .WithMany(u => u.Publicaciones) // Cada usuario puede tener múltiples publicaciones
                .HasForeignKey(x => x.UsuarioId); // Clave externa en la tabla Publicaciones

            // Configuración de la relación entre Publicación y Producto
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Producto)  // Una publicación tiene un producto asociado
                .WithOne(w => w.Publicacion)  // Un producto está asociado a una única publicación
                .HasForeignKey<Producto>(p => p.PublicacionId);  // Clave externa en la tabla Productos que referencia la tabla Publicaciones

            // Configuración de la relación entre Publicación y Preguntas
            modelBuilder.Entity<Publicacion>()
                .HasMany(x => x.Preguntas) // Una publicación puede tener muchas preguntas
                .WithOne(x => x.Publicacion) // Cada pregunta pertenece a una única publicación
                .HasForeignKey(p => p.PublicacionId); // Clave externa en la tabla Preguntas

            // Configuración de la relación entre Producto y Publicación
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Publicacion)  // Un producto está asociado a una única publicación
                .WithOne(w => w.Producto)  // No especificamos WithOne() ya que la relación es uno a uno o muchos a uno
                .HasForeignKey<Producto>(p => p.PublicacionId);  // Clave externa en la tabla Productos que referencia la tabla Publicaciones

            // Configuración de la relación entre Producto y Categoría
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)  // Un producto pertenece a una sola categoría
                .WithMany()  // No especificamos WithOne() ya que la relación es uno a uno o muchos a uno
                .HasForeignKey(p => p.CategoriaId)  // Clave externa en la tabla Productos que referencia la tabla Categorías
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION)

            // Configuración de la relación entre Pregunta y Publicación
            modelBuilder.Entity<Pregunta>()
                .HasOne(p => p.Publicacion)  // Una pregunta pertenece a una sola publicación
                .WithMany(p => p.Preguntas)  // Cada publicación puede tener muchas preguntas
                .HasForeignKey(p => p.PublicacionId);  // Clave externa en la tabla Preguntas

            // Genera la base de datos con categorías predefinidas
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "$0 a $5.000" },
                new Categoria { Id = 2, Nombre = "$5.000 a $10.000" },
                new Categoria { Id = 3, Nombre = "Mas de $10.000" }
            );

            // Genera la base de datos con una sucursal predefinida
            modelBuilder.Entity<Sucursal>().HasData(
                new Sucursal { Id = 1, Nombre = "Central", Direccion = "Calle 13 2500", Localidad = "La Plata" }
            );

            // Genera la base de datos con un usuario admin predefinido
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Admin", Apellido = "Admin", Email = "admin@admin", Contraseña = "admin", FechaNacimiento = DateOnly.MinValue, Rol = "Admin", SucursalId = 1 }
            );

        }

    }

}
