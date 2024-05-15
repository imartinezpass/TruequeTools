using TruequeTools.Entities;

namespace TruequeTools.Services
{
    public interface IServiciosOferta
    {
        public Task CreateOferta(Oferta oferta);
        public Task<List<Oferta>> ReadAllOfertas();
        public Task<List<Oferta>> ReadAllOfertasCurrentUser(int userId);
    }
}
