using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosProducto"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Producto"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosProducto(TruequeToolsDataContext context) : IServiciosProducto
    {

        private readonly TruequeToolsDataContext contexto = context;

        //RECIBE UN PRODUCTO COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
        public async Task CreateProducto(Producto producto)
        {
            contexto.Productos.Add(producto);
            await contexto.SaveChangesAsync();
        }

    }

}
