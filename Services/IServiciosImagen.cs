using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Imagen"

 */

namespace TruequeTools.Services
{
    public interface IServiciosImagen
    {
        public Task AltaImagenes(List<Imagen> imagenes);
        public Task BajaImagenesPorIdPublicacion(int idPublicacion);
    }
}
