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
    }
}
