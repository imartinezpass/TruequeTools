using TruequeTools.Data;
using TruequeTools.Entities;

namespace TruequeTools.Services
{
    public class ServiciosProducto : InterfazServiciosProducto
    {
        private readonly TruequeToolsDataContext contexto;

        public ServiciosProducto(TruequeToolsDataContext context)
        {
            contexto = context;
        }

        //RECIBE UN PRODUCTO COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
        public async Task CreateProducto(Producto producto)
        {
            contexto.Productos.Add(producto);
            await contexto.SaveChangesAsync();
        }

    }
}
