using Microsoft.EntityFrameworkCore;
using TruequeTools.Components.Pages;
using TruequeTools.Data;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosTrueque"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Imagen"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosTrueque(TruequeToolsDataContext context) : IServiciosTrueque
    {

        private readonly TruequeToolsDataContext contexto = context;

        public async Task CreateTrueque(Trueque t)
        {
            contexto.Trueques.Add(t);
            await contexto.SaveChangesAsync();
        }

		public async Task DeleteTruequePendienteBySucursal(int oldSucursalId)
		{
			var trueques = await contexto.Trueques.Where(x => x.Oferta!.PublicacionQueOferto!.SucursalId == oldSucursalId && x.Estado == 0).ToListAsync();

			foreach (var t in trueques)
			{
				contexto.Trueques.Remove(t);
			}

			await contexto.SaveChangesAsync();
		}

        public async Task<double> GetPromedioVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques.Include(t => t.Productos).Where(x => x.HasVentas == true && contexto.Ofertas.Any(o => o.Id == x.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin)).ToListAsync();
            return trueques.Average(t => t.Productos!.Sum(x => x.Monto * x.Cantidad));
        }

        public async Task<double> GetTotalVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques.Include(t => t.Productos).Where(x => x.HasVentas == true && contexto.Ofertas.Any(o => o.Id == x.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin)).ToListAsync();
            return trueques.Sum(t => t.Productos!.Sum(x => x.Monto * x.Cantidad));
        }

        public async Task<double> GetTotalVentasSucursal(int sucursalId, DateTime fechaInicio, DateTime fechaFin)
        {
            var result = await contexto.Trueques.Where(s => s.Oferta!.Usuario!.SucursalId == sucursalId && s.HasVentas == true && contexto.Ofertas.Any(o => o.Id == s.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin)).ToListAsync();
            return result.Sum(t => t.Productos!.Sum(x => x.Monto * x.Cantidad));
        }

        public async Task<Trueque> OverwriteTruequeById(Trueque trueque)
        {
           
            var truequeExistente = await contexto.Trueques.FindAsync(trueque.Id);

            if (truequeExistente != null)
            {
                truequeExistente = trueque;
                await contexto.SaveChangesAsync();

                return truequeExistente;
            }
            else
            {
                throw new Exception("El trueque no existe.");
            }
            
        }

        public async Task<List<Trueque>> ReadAllTrueques()
        {
            var result = await contexto.Trueques.ToListAsync();
            return result;
        }

        public async Task<List<Trueque>> ReadTruequesEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques
                .Where(t => contexto.Ofertas.Any(o => o.Id == t.OfertaId && o.Fecha >= fechaInicio && o.Fecha<=fechaFin))
                .ToListAsync();

            return trueques;
        }

        public async Task<Trueque> ReadTruequeById(int id)
        {
            var result = await contexto.Trueques.Where(s => s.Id == id).FirstOrDefaultAsync();
            return result!;
        }

        public async Task<List<Trueque>> ReadTruequesBySucursal(int sucursalId)
        {
            var result = await contexto.Trueques.Where(s => s.Oferta!.Usuario!.SucursalId == sucursalId).ToListAsync();
            return result;
        }
    }

}

