using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Oferta"

 */

namespace TruequeTools.Services
{
    public interface IServiciosOferta
    {
        public Task CreateOferta(Oferta oferta);
        public Task<List<Oferta>> ReadAllOfertas();
        public Task<List<Oferta>> ReadAllOfertasRealizadasCurrentUser(int userId);
    }
}
