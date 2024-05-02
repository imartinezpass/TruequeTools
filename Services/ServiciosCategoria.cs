using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

namespace TruequeTools.Services
{
    public class ServiciosCategoria : InterfazServiciosCategoria
    {
        private readonly TruequeToolsDataContext contexto;

        public ServiciosCategoria(TruequeToolsDataContext context)
        {
            contexto = context;
        }

        //DEVUELVE UNA LISTA CON TODAS LAS CATEGORIAS
        public async Task<List<Categoria>> ReadAllCategorias()
        {
            var result = await contexto.Categorias.ToListAsync();
            return result;
           
        }

    }
}
