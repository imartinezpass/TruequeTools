using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Trueque"

 */

namespace TruequeTools.Services
{
    public interface IServiciosTrueque
    {
        public Task CreateTrueque(Trueque t);
        public Task<Trueque> ReadTruequeById(int id);
        public Task<List<Trueque>> ReadAllTrueques();
        public Task<List<Trueque>> ReadTruequesBySucursal(int sucursalId);
        public Task<Trueque> OverwriteTruequeById(Trueque trueque);
        
    }
}
