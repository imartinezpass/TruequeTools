using TruequeTools.Data;
using TruequeTools.Entities;

namespace TruequeTools.Services
{
    public class ServiciosPublicacion : InterfazServiciosPublicacion
    {
        private readonly TruequeToolsDataContext contexto;

        public ServiciosPublicacion(TruequeToolsDataContext context)
        {
            contexto = context;
        }

        //RECIBE UNA PUBLICACION COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
        public async Task CreatePublicacion(Publicacion publicacion)
        {
            contexto.Publicaciones.Add(publicacion);
            await contexto.SaveChangesAsync();
        }
    }
}
