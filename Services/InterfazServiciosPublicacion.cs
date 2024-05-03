using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Publicacion"

 */

namespace TruequeTools.Services
{
    public interface InterfazServiciosPublicacion
    {
        public Task CreatePublicacion(Publicacion publicacion); //Create

    }
}
