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

        //DEVUELVE UNA LISTA CON TODAS LAS PUBLICACIONES
        public async Task<List<Publicacion>> ReadAllPublicaciones()
        {
            var result = await contexto.Publicaciones.ToListAsync();
            return result;
        }

        //DEVUELVE UNA LISTA CON TODAS LAS PUBLICACIONES DEL USUARIO PASADO COMO PARAMETRO
        public async Task<List<Publicacion>> ReadAllPublicacionesCurrentUser(int userId)
        {
            var publicaciones = await (from p in contexto.Publicaciones join u in contexto.Usuarios on p.UsuarioId equals userId select p).ToListAsync();
            return publicaciones;
        }

        //DEVUELVE LA PUBLICACION CON EL ID PASADO COMO PARAMETRO O UNA PUBLICACION VACIA EN CASO DE NO ENCONTRARLA
        public async Task<Publicacion> ReadPublicacionById(int id)
        {
            IQueryable<Publicacion> query = contexto.Publicaciones.Where(p => p.Id == id);
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

        //DEVUELVE UNA LISTA CON PUBLICACIONES QUE POSEAN EL STRING "unTitulo" EN EL TITULO DE LA PUBLCIACION
        public async Task<List<Publicacion>> ReadPublicacionesByNombre(string unTitulo)
        {
            var result = await contexto.Publicaciones.Where(publicacion => publicacion.Titulo!.Contains(unTitulo)).ToListAsync();
            return result;
        }

    }

}