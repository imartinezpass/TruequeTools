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
        public Task<List<Trueque>> ReadTruequesEntreFechas(DateTime fechaInicio, DateTime fechaFin);
        public Task<List<Trueque>> ReadTruequesEntreFechasConVentas(DateTime fechaInicio, DateTime fechaFin);
        public Task<List<Trueque>> ReadTruequesEntreFechasYSucursal(DateTime fechaInicio, DateTime fechaFin, int sucursalId);
        public Task<List<Trueque>> ReadTruequesEntreFechasYSucursalConVentas(DateTime fechaInicio, DateTime fechaFin, int sucursalId);
        public Task<List<Trueque>> ReadTruequesBySucursal(int sucursalId);
        public Task<Trueque> OverwriteTruequeById(Trueque trueque);
		public Task DeleteTruequePendienteBySucursal(int sucursalId);
        public Task<double> GetMontoVentas(int idTrueque);
        public Task<double> GetTotalVentas(DateTime fechaInicio, DateTime fechaFin);
        public Task<double> GetPromedioVentas(DateTime fechaInicio, DateTime fechaFin);
        public Task<double> GetPromedioVentasSucursal(int sucursalId, DateTime fechaInicio, DateTime fechaFin);
        public Task<double> GetTotalVentasSucursal(int sucursalId, DateTime fechaInicio, DateTime fechaFin);

	}
}
