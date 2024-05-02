using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Producto"

 */

namespace TruequeTools.Services
{
    public interface InterfazServiciosProducto
    {
        public Task CreateProducto(Producto producto); //Create
    }

}
