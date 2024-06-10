using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;

/*

Esta clase implementa los servicios que establece la interfaz "InterfazServiciosOferta"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Producto"

*/

namespace TruequeTools.Services
{
    public class ServiciosOferta(TruequeToolsDataContext context) : IServiciosOferta
    {

        private readonly TruequeToolsDataContext contexto = context;

        //RECIBE UNA OFERTA COMO PARAMETRO Y LA AGREGA A LA BASE DE DATOS
        public async Task CreateOferta(Oferta oferta)
        {
            contexto.Ofertas.Add(oferta);
            await contexto.SaveChangesAsync();
        }

        //DEVUELVE UNA LISTA CON TODAS LAS OFERTAS DE LA BASE DE DATOS
        public async Task<List<Oferta>> ReadAllOfertas()
        {
            var result = await contexto.Ofertas.ToListAsync();
            return result;
        }

        public async Task<List<Oferta>> ReadAllOfertasRealizadasByUser(int userId)
        {
            var ofertas = await contexto.Ofertas.Where(p => p.UsuarioId == userId).ToListAsync();
            return ofertas!; 
        }

        //SOBREESCRIBE UNA OFERTA BUSCANDOLA POR EL ID
        public async Task<Oferta> OverwriteOfertaById(Oferta oferta)
        {

            var ofertaExistente = oferta;
            await contexto.SaveChangesAsync();

            return ofertaExistente;
             
        }

        //CAMBIA EL ESTADO DE TODAS LAS OFERTAS CON CIERTO ID DE PUBLICACION OFERTADA O OFRECIDA A RECHAZADA
        public async Task RechazarOfertasTruequeCompletado(int publicacionId, string motivo)
        {
            var ofertas1 = await contexto.Ofertas
                .Where(oferta => oferta.PublicacionQueOfertoId == publicacionId && oferta.Estado == 0).ToListAsync();

			var ofertas2 = await contexto.Ofertas
				.Where(oferta => oferta.PublicacionQueOfrezcoId == publicacionId && oferta.Estado == 0).ToListAsync();

			foreach (var oferta in ofertas2)
            {
                oferta.Estado = -1;
                oferta.Motivo = motivo;
            }

			contexto.Ofertas.RemoveRange(ofertas1);

			await contexto.SaveChangesAsync();
        }

        //BUSCA SI UNA PUBLICACION ESTA INVOLUCRADA EN UNA OFERTA ACEPTADA
        public async Task<bool> PublicacionComprometida(int publicacionId)
        {
            var ofertaAceptada = await contexto.Ofertas
                .AnyAsync(oferta =>
                    (oferta.PublicacionQueOfertoId == publicacionId || oferta.PublicacionQueOfrezcoId == publicacionId)
                    && oferta.Estado == 1);

            return ofertaAceptada;
        }

        public async Task<Oferta> ReadOfertaById(int id)
        {
            var result = await contexto.Ofertas.Where(s => s.Id == id).FirstOrDefaultAsync();
            return result!;
        }

        public Task<bool> PublicacionHasOfertas(int publicacionId)
        {
            return contexto.Ofertas.AnyAsync(o => o.PublicacionQueOfertoId == publicacionId || o.PublicacionQueOfrezcoId == publicacionId);
        }
    }

}
