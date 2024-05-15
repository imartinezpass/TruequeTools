using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;


namespace TruequeTools.Services
/*

Esta clase implementa los servicios que establece la interfaz "InterfazServiciosOferta"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Producto"

*/
{
    public class ServiciosOferta(TruequeToolsDataContext context) : IServiciosOferta
    {
        private readonly TruequeToolsDataContext contexto = context;
        public async Task CreateOferta(Oferta oferta)
        {
            contexto.Ofertas.Add(oferta);
            await contexto.SaveChangesAsync();
        }

        public async Task<List<Oferta>> ReadAllOfertas()
        {
            var result = await contexto.Ofertas.ToListAsync();
            return result;
        }

        public async Task<List<Oferta>> ReadAllOfertasCurrentUser(int userId)
        {
            var ofertas = await (from o in contexto.Ofertas
                                 join p in contexto.Publicaciones on o.PublicacionId equals p.Id
                                 join u in contexto.Usuarios on p.UsuarioId equals userId
                                 select o
                                 ).ToListAsync();
            return ofertas;
        }
    }
}
