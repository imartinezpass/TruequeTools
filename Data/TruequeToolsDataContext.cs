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
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		
	}

}
