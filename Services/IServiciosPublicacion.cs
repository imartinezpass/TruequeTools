using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Publicacion"

 */

namespace TruequeTools.Services
{
    public interface IServiciosPublicacion
    {
        public Task<int> CreatePublicacion(Publicacion publicacion);
        public Task<Publicacion> ReadPublicacionById(int id);
        public Task<List<Publicacion>> ReadPublicacionesByNombre(string titulo);
        public Task<List<Publicacion>> ReadAllPublicaciones();
        public Task<List<Publicacion>> ReadAllPublicacionesActivasCurrentUser(int userId);
        public Task<List<Publicacion>> ReadAllPublicacionesCurrentUser(int userId);
        public Task<List<Oferta>> ReadAllOfertasOfPublicacion(int publicacionId);

    }
}
