using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Sucursal"

 */

namespace TruequeTools.Services
{
    public interface IServiciosSucursal
	{
		public Task<List<Sucursal>> ReadAllSucursales(); //Read All
		public Task CreateSucursal(Sucursal sucursal); //Create
		public Task<Sucursal> ReadSucursalById(int id); //Read
		public Task UpdateSucursal(Sucursal sucursal, int id); //Update
		public Task DeleteSucursal(int id); //Delete
	}

}
