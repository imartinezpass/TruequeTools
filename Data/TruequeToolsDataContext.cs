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
    public class TruequeToolsDataContext(DbContextOptions<TruequeToolsDataContext> options) : DbContext(options)
    {

        //VINCULO ENTRE LA BASE DE DATOS Y LAS ENTIDADES
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        //VINCULO ENTRE LA BASE DE DATOS Y LAS ENTIDADES

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Oferta y Publicacion
            modelBuilder.Entity<Oferta>()
               .HasOne(x => x.Publicacion)
               .WithMany(u => u.Ofertas)
               .HasForeignKey(x => x.PublicacionId);

            // Configuración de la relación entre Oferta y Usuario
            modelBuilder.Entity<Oferta>()
               .HasOne(x => x.Usuario)
               .WithMany(u => u.Ofertas)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Publicacion y Oferta
            modelBuilder.Entity<Publicacion>()
                .HasMany(x => x.Ofertas)
                .WithOne(x => x.Publicacion)
                .HasForeignKey(x => x.PublicacionId);

            // Configuración de la relación entre Usuario y Oferta
            modelBuilder.Entity<Usuario>()
               .HasMany(x => x.Ofertas)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.UsuarioId);

            // Configuración de la relación entre Usuario y Pregunta
            modelBuilder.Entity<Usuario>()
               .HasMany(x => x.Preguntas)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.UsuarioId);

            // Configuración de la relación entre Pregunta y Usuario
            modelBuilder.Entity<Pregunta>()
               .HasOne(x => x.Usuario)
               .WithMany(u => u.Preguntas)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Usuario y Sucursal
            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Sucursal)  
                .WithMany()
                .HasForeignKey(x => x.SucursalId)  
                .OnDelete(DeleteBehavior.Restrict);  

            // Configuración de la relación entre Usuario y Publicacion
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Publicaciones) 
                .WithOne(x => x.Usuario) 
                .HasForeignKey(x => x.UsuarioId);

            // Configuración de la relación entre Publicacion y Sucursal
            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Sucursal) 
                .WithMany()  
                .HasForeignKey(x => x.SucursalId) 
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Publicacion y Usuario
            modelBuilder.Entity<Publicacion>()
                .HasOne(x => x.Usuario)  
                .WithMany(u => u.Publicaciones) 
                .HasForeignKey(x => x.UsuarioId); 

            // Configuración de la relación entre Publicacion y Producto
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Producto)  
                .WithOne(w => w.Publicacion) 
                .HasForeignKey<Producto>(p => p.PublicacionId);

            // Configuración de la relación entre Publicacion y Pregunta
            modelBuilder.Entity<Publicacion>()
                .HasMany(x => x.Preguntas) 
                .WithOne(x => x.Publicacion)
                .HasForeignKey(p => p.PublicacionId); 

            // Configuración de la relación entre Producto y Publicacion
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Publicacion)  
                .WithOne(w => w.Producto) 
                .HasForeignKey<Producto>(p => p.PublicacionId);  

            // Configuración de la relación entre Producto y Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)  
                .WithMany()  
                .HasForeignKey(p => p.CategoriaId)  
                .OnDelete(DeleteBehavior.Restrict);  

            // Configuración de la relación entre Pregunta y Publicacion
            modelBuilder.Entity<Pregunta>()
                .HasOne(p => p.Publicacion)  
                .WithMany(p => p.Preguntas)  
                .HasForeignKey(p => p.PublicacionId); 

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
