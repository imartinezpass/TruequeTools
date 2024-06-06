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
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trueque> Trueques { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        //VINCULO ENTRE LA BASE DE DATOS Y LAS ENTIDADES

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ENTIDAD TRUEQUE

            modelBuilder.Entity<Trueque>() // Configuración de la relación entre Trueque y Oferta
               .HasOne(x => x.Oferta)
               .WithOne(x => x.Trueque)
               .HasForeignKey<Trueque>(x => x.OfertaId);

            modelBuilder.Entity<Trueque>() // Configuración de la relación entre Trueque y Productos
                .HasMany(x => x.Productos)
                .WithOne()
                .HasForeignKey(p => p.TruequeId);

            //ENTIDAD USUARIO

            modelBuilder.Entity<Usuario>() // Configuración de la relación entre Usuario y Sucursal
                .HasOne(x => x.Sucursal)
                .WithMany()
                .HasForeignKey(x => x.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()  // Configuración de la relación entre Usuario y Oferta
               .HasMany(x => x.Ofertas)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<Usuario>() // Configuración de la relación entre Usuario y Pregunta
               .HasMany(x => x.Preguntas)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<Usuario>() // Configuración de la relación entre Usuario y Publicacion
                .HasMany(x => x.Publicaciones)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

            //ENTIDAD PREGUNTA

            modelBuilder.Entity<Pregunta>() // Configuración de la relación entre Pregunta y Usuario
               .HasOne(x => x.Usuario)
               .WithMany(u => u.Preguntas)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pregunta>() // Configuración de la relación entre Pregunta y Publicacion
                .HasOne(p => p.Publicacion)
                .WithMany(p => p.Preguntas)
                .HasForeignKey(p => p.PublicacionId);

            //ENTIDAD PUBLICACION

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion y Categoria
                .HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion y Sucursal
               .HasOne(x => x.Sucursal)
               .WithMany()
               .HasForeignKey(x => x.SucursalId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Publicacion>()  // Configuración de la relación entre Publicacion y Usuario
                .HasOne(x => x.Usuario)
                .WithMany(u => u.Publicaciones)
                .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion y Pregunta
                .HasMany(x => x.Preguntas)
                .WithOne(x => x.Publicacion)
                .HasForeignKey(p => p.PublicacionId);

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion e Imagen
                .HasMany(x => x.Imagenes)
                .WithOne()
                .HasForeignKey(p => p.PublicacionId);

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion y Oferta (sobre publicacion)
                .HasMany(x => x.OfertasRealizadas)
                .WithOne(x => x.PublicacionQueOferto)
                .HasForeignKey(x => x.PublicacionQueOfertoId);

            modelBuilder.Entity<Publicacion>() // Configuración de la relación entre Publicacion y Oferta (hacia publicacion)
                .HasMany(x => x.OfertasRecibidas)
                .WithOne(x => x.PublicacionQueOfrezco)
                .HasForeignKey(x => x.PublicacionQueOfrezcoId);

            //ENTIDAD OFERTA

            modelBuilder.Entity<Oferta>() // Configuración de la relación entre Oferta y Usuario
               .HasOne(x => x.Usuario)
               .WithMany(u => u.Ofertas)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Oferta>() // Configuración de la relación entre Oferta y Publicacion (sobre publicacion)
               .HasOne(x => x.PublicacionQueOferto)
               .WithMany(u => u.OfertasRealizadas)
               .HasForeignKey(x => x.PublicacionQueOfertoId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Oferta>() // Configuración de la relación entre Oferta y Publicacion (hacia publicacion)
               .HasOne(x => x.PublicacionQueOfrezco)
               .WithMany(u => u.OfertasRecibidas)
               .HasForeignKey(x => x.PublicacionQueOfrezcoId);

            // Genera la base de datos con las categorías predefinidas
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "$0 a $5.000" },
                new Categoria { Id = 2, Nombre = "$5.000 a $10.000" },
                new Categoria { Id = 3, Nombre = "Mas de $10.000" }
            );

            // Genera la base de datos con 3 sucursales predefinidas
            modelBuilder.Entity<Sucursal>().HasData(
                new Sucursal { Id = 1, Nombre = "Central", Direccion = "Calle 13 y 38", Localidad = "La Plata" },
                new Sucursal { Id = 2, Nombre = "Los Hornos", Direccion = "Calle 66 y 137", Localidad = "La Plata" },
                new Sucursal { Id = 3, Nombre = "City Bell", Direccion = "Jorge Bell y Cantilo", Localidad = "La Plata" }
            );

            // Genera la base de datos con un usuario de cada tipo predefinidos
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Admin", Apellido = "Admin", Email = "admin@admin", Contraseña = "admin", FechaNacimiento = DateOnly.MinValue, Rol = "Admin", SucursalId = 1 },
                new Usuario { Id = 2, Nombre = "User", Apellido = "User", Email = "user@user", Contraseña = "user", FechaNacimiento = DateOnly.MinValue, Rol = "User", SucursalId = 1 },
				new Usuario { Id = 3, Nombre = "Employee", Apellido = "Employee", Email = "employee@employee", Contraseña = "employee", FechaNacimiento = DateOnly.MinValue, Rol = "Employee", SucursalId = 1 }
			);

        }

    }

}
