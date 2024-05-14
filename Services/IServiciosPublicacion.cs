using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Publicacion"

 */

namespace TruequeTools.Services
{
    public interface IServiciosPublicacion
    {
        public Task<int> CreatePublicacion(Publicacion publicacion); //Create
        public Task<Publicacion> ReadPublicacionById(int id); //Read
        public Task<List<Publicacion>> ReadAllPublicaciones(); // martin

    }
}
