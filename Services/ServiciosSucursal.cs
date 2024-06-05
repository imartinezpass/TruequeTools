using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosSucursal"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Sucursal"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosSucursal(TruequeToolsDataContext context) : IServiciosSucursal
	{

		private readonly TruequeToolsDataContext contexto = context;

        //DEVUELVE UNA LISTA CON TODAS LAS SUCURSALES
        public async Task<List<Sucursal>> ReadAllSucursales()
		{
			var result = await contexto.Sucursales.Where(s => !s.Deleted).ToListAsync();
			return result;
		}

        //RECIBE UNA SUCURSAL COMO PARAMETRO Y LA AGREGA A LA BASE DE DATOS
        public async Task CreateSucursal(Sucursal sucursal)
		{
			contexto.Sucursales.Add(sucursal);
			await contexto.SaveChangesAsync();
		}

		//RECIBE UN ID Y DEVUELVE LA SUCURSAL CORRESPONDIENTE A DICHO ID
		public async Task<Sucursal> ReadSucursalById(int id)
		{
            var sucursal = await contexto.Sucursales.FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
			if (sucursal != null)
			{
				return sucursal;
			}
			else
			{
				return new Sucursal { Nombre = "Sucursal", Direccion = "Direccion", Localidad="Localidad"};
			}
		}

		//RECIBE UNA SUCURSAL Y UN ID - ACTUALIZA LA SUCURSAL EXISTENTE O CREA UNA NUEVA
		public async Task UpdateSucursal(Sucursal sucursal, int id)
		{
			var updatedSucursal = await contexto.Sucursales.FindAsync(id);
			if (updatedSucursal != null)
			{
				updatedSucursal.Nombre = sucursal.Nombre;
				updatedSucursal.Direccion = sucursal.Direccion;
				updatedSucursal.Localidad = sucursal.Localidad;
				await contexto.SaveChangesAsync();
			}
		}

		//RECIBE UN ID Y ELIMINA LA SUCURSAL CORRESPONDIENTE A DICHO ID
		public async Task DeleteSucursal(int id)
		{
			var sucursal = await contexto.Sucursales.FindAsync(id);
			if (sucursal != null)
			{
				sucursal.Deleted = true;
				await contexto.SaveChangesAsync();
			}
		}

		public async Task<bool> ExisteSucursal(string nombreSucursal, int? id = null)
		{
			return await contexto.Sucursales.AnyAsync(x => x.Nombre == nombreSucursal && !x.Deleted && (!id.HasValue || x.Id != id.Value));
		}
	}

}
