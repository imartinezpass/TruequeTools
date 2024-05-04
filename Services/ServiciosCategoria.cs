using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosCategoria"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Categoria"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosCategoria(TruequeToolsDataContext context) : IServiciosCategoria
    {

        private readonly TruequeToolsDataContext contexto = context;

        //DEVUELVE UNA LISTA CON TODAS LAS CATEGORIAS
        public async Task<List<Categoria>> ReadAllCategorias()
        {
            var result = await contexto.Categorias.ToListAsync();
            return result;
           
        }

    }

}
