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
        public Task<List<Publicacion>> ReadPublicacionesByNombre(string titulo); //Read
        public Task<List<Publicacion>> ReadAllPublicaciones(); //Read
        public Task<List<Publicacion>> ReadAllPublicacionesCurrentUser(int userId);

    }
}
