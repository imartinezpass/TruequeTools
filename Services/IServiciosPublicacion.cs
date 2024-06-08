using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Publicacion"

 */

namespace TruequeTools.Services
{
    public interface IServiciosPublicacion
    {
        public Task<int> CreatePublicacion(Publicacion publicacion);
        public Task<Publicacion> ReadPublicacionById(int id, bool includeDeleted = false);
        public Task<List<Publicacion>> ReadPublicacionesByNombre(string titulo);
        public Task<List<Publicacion>> ReadPublicacionesActivasByNombre(string titulo);
        public Task<List<Publicacion>> ReadAllPublicaciones();
        public Task<List<Publicacion>> ReadAllPublicacionesActivas();
        public Task<List<Publicacion>> ReadAllPublicacionesActivas12();
        public Task<List<Publicacion>> ReadAllPublicacionesActivasCurrentUser(int userId);
        public Task<List<Publicacion>> ReadAllPublicacionesCurrentUser(int userId);
        public Task<Publicacion> OverwritePublicacionById(Publicacion publicacion);
        public Task<List<Oferta>> ReadAllOfertasOfPublicacion(int publicacionId);

    }
}
