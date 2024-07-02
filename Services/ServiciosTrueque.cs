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
            var trueques = await contexto.Trueques
                .Include(t => t.Productos)
                .Where(t => contexto.Ofertas.Any(o => o.Id == t.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin))
                .ToListAsync();

            double totalVentas = trueques.Sum(t => t.Productos!.Sum(p => p.Monto * p.Cantidad));
            int totalTrueques = trueques.Count;

            return totalTrueques > 0 ? totalVentas / totalTrueques : 0;
        }

        public async Task<double> GetPromedioVentasSucursal(int sucursalId, DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques
                .Include(t => t.Productos)
                .Include(t => t.Oferta)
                    .ThenInclude(o => o!.PublicacionQueOfrezco)
                .Where(t => t.Oferta!.PublicacionQueOfrezco!.SucursalId == sucursalId &&
                            t.Oferta.Fecha >= fechaInicio &&
                            t.Oferta.Fecha <= fechaFin)
                .ToListAsync();

            double totalVentas = trueques.Sum(t => t.Productos!.Sum(p => p.Monto * p.Cantidad));
            int totalTrueques = trueques.Count;

            return totalTrueques > 0 ? totalVentas / totalTrueques : 0;
        }

        public async Task<double> GetTotalVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques.Include(t => t.Productos).Where(x => x.HasVentas == true && contexto.Ofertas.Any(o => o.Id == x.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin)).ToListAsync();
            return trueques.Sum(t => t.Productos!.Sum(x => x.Monto * x.Cantidad));
        }

        public async Task<double> GetMontoVentas(int idTrueque)
        {
            var trueque = await contexto.Trueques.FindAsync(idTrueque);

            return trueque!.Productos!.Sum(x => x.Monto * x.Cantidad);
        }

        public async Task<double> GetTotalVentasSucursal(int sucursalId, DateTime fechaInicio, DateTime fechaFin)
        {
            var result = await contexto.Trueques
                .Include(t => t.Oferta)
                .ThenInclude(o => o!.PublicacionQueOfrezco) // Incluimos la publicacion ofrecida que debería tener la sucursal
                .Where(t => t.Oferta!.PublicacionQueOfrezco!.SucursalId == sucursalId &&
                            t.HasVentas == true &&
                            t.Oferta.Fecha >= fechaInicio &&
                            t.Oferta.Fecha <= fechaFin)
                .SelectMany(t => t.Productos!)
                .SumAsync(p => p.Monto * p.Cantidad);
            return result;
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
                .Where(t => contexto.Ofertas.Any(o => o.Id == t.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin))
                .ToListAsync();

            return trueques;
        }

        public async Task<List<Trueque>> ReadTruequesEntreFechasConVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var trueques = await contexto.Trueques
                .Where(t => t.HasVentas== true && contexto.Ofertas.Any(o => o.Id == t.OfertaId && o.Fecha >= fechaInicio && o.Fecha <= fechaFin))
                .ToListAsync();

            return trueques;
        }

        public async Task<List<Trueque>> ReadTruequesEntreFechasYSucursal(DateTime fechaInicio, DateTime fechaFin, int sucursalId)
        {
            var trueques = await contexto.Trueques
                .Include(t => t.Oferta)
                .ThenInclude(o => o!.PublicacionQueOfrezco)
                .Where(t => t.Oferta!.PublicacionQueOfrezco!.SucursalId == sucursalId &&
                    t.Oferta.Fecha >= fechaInicio &&
                    t.Oferta.Fecha <= fechaFin)
                .ToListAsync();

            return trueques;
        }

        public async Task<List<Trueque>> ReadTruequesEntreFechasYSucursalConVentas(DateTime fechaInicio, DateTime fechaFin, int sucursalId)
        {
            var trueques = await contexto.Trueques
                .Include(t => t.Oferta)
                .ThenInclude(o => o!.PublicacionQueOfrezco)
                .Where(t => t.Oferta!.PublicacionQueOfrezco!.SucursalId == sucursalId &&
                    t.HasVentas == true &&
                    t.Oferta.Fecha >= fechaInicio &&
                    t.Oferta.Fecha <= fechaFin)
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
            var result = await contexto.Trueques
                .Include(t => t.Oferta)
                .ThenInclude(o => o!.PublicacionQueOfrezco)
                .Where(t => t.Oferta!.PublicacionQueOfrezco!.SucursalId == sucursalId).ToListAsync();
            return result;
        }
    }

}

