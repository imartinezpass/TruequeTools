using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase establece el contexto de la base de datos SQL usando MicrosoftEntityFrameworkCore
Todo lo que se modifique aca afecta la estructura de la base de datos SQL

Si se agregan DbSet nuevos primero se debe crear una nueva migracion con: Add-Migration "nombre_de_la_migracion"
Luego se debe actualizar la base de datos con: Update-Database
 
 */

namespace TruequeTools.Data
{
    public class TruequeToolsDataContext : DbContext
	{

		public TruequeToolsDataContext(DbContextOptions<TruequeToolsDataContext> options) : base(options)
		{
		
		}

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Comentarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Sucursal)  // Configura la relación: un usuario pertenece a una única sucursal.
                .WithMany()  // No especificamos WithOne() aquí ya que la relación es uno a uno o muchos a uno.
                .HasForeignKey(x => x.SucursalId)  // Clave externa en la tabla usuarios que referencia la tabla sucursales.
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION).

            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Publicaciones) // Configura la relación: un usuario puede tener muchas publicaciones.
                .WithOne(x => x.Usuario) // Configura la relación inversa: cada publicación pertenece a un único usuario.
                .HasForeignKey(x => x.UsuarioId); // Clave externa en la tabla Publicacion.

            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Sucursal)  // Configura la relación: una publicación pertenece a una única sucursal.
                .WithMany()  // No especificamos WithOne() aquí ya que la relación es uno a uno o muchos a uno.
                .HasForeignKey(x => x.SucursalId)  // Clave externa en la tabla publicaciones que referencia la tabla sucursales.
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION).

            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Usuario)
                .WithMany(u => u.Publicaciones) // Aquí especificamos la propiedad de navegación inversa
                .HasForeignKey(x => x.UsuarioId); // Clave externa en la tabla Publicacion

            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Producto)  // Configura la relación: una publicación tiene un único producto asociado.
                .WithMany()  // No especificamos WithOne() aquí ya que la relación es uno a uno o muchos a uno.
                .HasForeignKey(x => x.ProductoId);  // Clave externa en la tabla Publicacion.

            modelBuilder.Entity<Publicacion>()
                .HasMany(x => x.Preguntas) // Configura la relación: una publicación puede tener muchas preguntas.
                .WithOne(x => x.Publicacion) // Configura la relación inversa: cada pregunta pertenece a una única publicación.
                .HasForeignKey(p => p.PublicacionId); // Clave externa en la tabla Pregunta.

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)  // Configura la relación: un producto pertenece a una sola categoría.
                .WithMany()  // No especificamos WithOne() aquí ya que la relación es uno a uno o muchos a uno.
                .HasForeignKey(p => p.CategoriaId)  // Clave externa en la tabla productos que referencia la tabla categorías.
                .OnDelete(DeleteBehavior.Restrict);  // Establece la acción en la eliminación a "Restrict" (NO ACTION).

            modelBuilder.Entity<Pregunta>()
                .HasOne(x => x.Publicacion)
                .WithMany(p => p.Preguntas) // Aquí especificamos la propiedad de navegación inversa
                .HasForeignKey(x => x.PublicacionId); // Clave externa en la tabla Pregunta

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "$0 a $5.000" },
                new Categoria { Id = 2, Nombre = "$5.000 a $10.000" },
                new Categoria { Id = 3, Nombre = "Mas de $10.000" }
                );

            modelBuilder.Entity<Sucursal>().HasData(
                new Sucursal { Id = 1, Nombre = "Central", Direccion = "Calle 13 2550", Localidad = "La Plata" }
                );


        }

    }

}
