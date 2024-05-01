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
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DEFINE LAS 3 CATEGORIAS AL CREAR LA BASE DE DATOS
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "$0 a $5.000" },
                new Categoria { Id = 2, Nombre = "$5.000 a $10.000" },
                new Categoria { Id = 3, Nombre = "Mas de $10.000" }
                );

            //DEFINE LA SUCURSAL CENTRAL
            modelBuilder.Entity<Sucursal>().HasData(
                new Sucursal { Id = 1, Nombre = "Central", Direccion = "Calle 13 2550", Localidad = "La Plata" }
                );

        }

    }

}
