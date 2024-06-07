using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosPublicacion"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Publicacion"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosPublicacion(TruequeToolsDataContext context) : IServiciosPublicacion
    {

        private readonly TruequeToolsDataContext contexto = context;

        //RECIBE UNA PUBLICACION COMO PARAMETRO Y LA AGREGA A LA BASE DE DATOS
        public async Task<int> CreatePublicacion(Publicacion publicacion)
        {
            contexto.Publicaciones.Add(publicacion);
            await contexto.SaveChangesAsync();
            return publicacion.Id;
        }

        public async Task<List<Oferta>> ReadAllOfertasOfPublicacion(int publicacionId)
        {
            return await contexto.Ofertas
            .Where(o => o.PublicacionQueOfrezcoId == publicacionId)
            .ToListAsync();
        }

        //DEVUELVE UNA LISTA CON TODAS LAS PUBLICACIONES
        public async Task<List<Publicacion>> ReadAllPublicaciones()
        {
            var result = await contexto.Publicaciones.ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON LAS PUBLICACIONES ACTIVAS
        public async Task<List<Publicacion>> ReadAllPublicacionesActivas()
        {
            var result = await contexto.Publicaciones.Where(p => p.Deleted == false).ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON LAS PRIMERAS 12 PUBLICACIONES ACTIVAS
        public async Task<List<Publicacion>> ReadAllPublicacionesActivas12()
        {
            var result = await contexto.Publicaciones.Where(p => p.Deleted == false).Take(12).ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON TODAS LAS PUBLICACIONES DEL USUARIO PASADO COMO PARAMETRO
        public async Task<List<Publicacion>> ReadAllPublicacionesCurrentUser(int userId)
        {
            var publicaciones = await contexto.Publicaciones.Where(p => p.UsuarioId == userId).ToListAsync();
            return publicaciones!;
        }

        //DEVUELVE UNA LISTA CON TODAS LAS PUBLICACIONES ACTIVAS DEL USUARIO PASADO COMO PARAMETRO
        public async Task<List<Publicacion>> ReadAllPublicacionesActivasCurrentUser(int userId)
        {
            var publicaciones = await contexto.Publicaciones.Where(p => p.UsuarioId == userId & p.Deleted==false).ToListAsync();
            return publicaciones!;
        }

        //DEVUELVE LA PUBLICACION CON EL ID PASADO COMO PARAMETRO O UNA PUBLICACION VACIA EN CASO DE NO ENCONTRARLA
        public async Task<Publicacion> ReadPublicacionById(int id)
        {
            IQueryable<Publicacion> query = contexto.Publicaciones.Where(p => p.Id == id && p.Deleted == false);
            var publicacion = await query.FirstOrDefaultAsync();

            if (publicacion != null)
            {
                return publicacion;
            }
            else
            {
                return new Publicacion();
            }
        }

        //SOBREESCRIBE UNA PUBLICACION BUSCANDOLA POR EL ID
        public async Task<Publicacion> OverwritePublicacionById(Publicacion publicacion)
        {
            var publicacionExistente = await contexto.Publicaciones.FindAsync(publicacion.Id);  // Buscar la publicación existente por su ID

            if (publicacionExistente != null)
            {
                publicacionExistente = publicacion;
                await contexto.SaveChangesAsync();

                return publicacionExistente;
            }
            else
            {
                throw new Exception("La publicación no existe.");
            }
        }

        //DEVUELVE UNA LISTA CON PUBLICACIONES ACTIVAS QUE POSEAN EL STRING "unTitulo" EN EL TITULO DE LA PUBLCIACION
        public async Task<List<Publicacion>> ReadPublicacionesActivasByNombre(string unTitulo)
        {
            var result = await contexto.Publicaciones.Where(p => p.Nombre!.Contains(unTitulo) & p.Deleted == false).ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON PUBLICACIONES QUE POSEAN EL STRING "unTitulo" EN EL TITULO DE LA PUBLCIACION
        public async Task<List<Publicacion>> ReadPublicacionesByNombre(string unTitulo)
        {
            var result = await contexto.Publicaciones.Where(p => p.Nombre!.Contains(unTitulo)).ToListAsync();
            return result;
        }

    }

}