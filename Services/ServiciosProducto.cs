using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosProducto"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Imagen"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosProducto(TruequeToolsDataContext context) : IServiciosProducto
    {

        private readonly TruequeToolsDataContext contexto = context;

        public async Task CargarProductos(List<Producto> productos)
        {
            foreach (Producto p in productos) 
            { 
                contexto.Productos.Add(p);
                await contexto.SaveChangesAsync();
            }
        }

        public async Task<List<Producto>> ReadProductosByTruequeId(int TruequeId)
        {
            var productos = await contexto.Productos.Where(p => p.TruequeId == TruequeId).ToListAsync();
            return productos!;
        }
    }

}
