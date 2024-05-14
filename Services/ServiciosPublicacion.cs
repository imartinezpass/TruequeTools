using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<List<Publicacion>> ReadPublicacionesByNombre(string titulo)
        {
            var result = await contexto.Publicaciones.Where(publicacion => publicacion.Titulo == titulo).ToListAsync();
            return result;
        }

    }


}

 }

