using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Producto"

 */

namespace TruequeTools.Services
{
    public interface IServiciosProducto
    {
        public Task CargarProductos(List<Producto> productos);
        public Task<List<Producto>> ReadProductosByTruequeId(int id);
    }
}
