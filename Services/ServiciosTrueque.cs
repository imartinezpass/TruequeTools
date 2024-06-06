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

        public async Task<Trueque> ReadTruequeById(int id)
        {
            var result = await contexto.Trueques.Where(s => s.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Trueque>> ReadTruequesPendientesBySucursal(int sucursalId)
        {
            var result = await contexto.Trueques.Where(s => s.Oferta!.Usuario!.SucursalId == sucursalId).ToListAsync();
            return result;
        }
    }

}

