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

        //RECIBE UNA PUBLICACION COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
        public async Task<int> CreatePublicacion(Publicacion publicacion)
        {
            contexto.Publicaciones.Add(publicacion);
            await contexto.SaveChangesAsync();
            return publicacion.Id;
        }

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
        // martin: tuve que agregar esto para resolver una oferta por una publicacion que no existe
        public async Task<List<Publicacion>> ReadAllPublicaciones()
        {
            var result = await contexto.Publicaciones.ToListAsync();
            return result;
        }

    }

}
