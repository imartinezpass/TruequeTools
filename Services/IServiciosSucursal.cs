using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Sucursal"

 */

namespace TruequeTools.Services
{
    public interface IServiciosSucursal
	{
		public Task<List<Sucursal>> ReadAllSucursales();
		public Task CreateSucursal(Sucursal sucursal);
		public Task<Sucursal> ReadSucursalById(int id);
		public Task UpdateSucursal(Sucursal sucursal, int id);
		public Task DeleteSucursal(int id);
	}
}
