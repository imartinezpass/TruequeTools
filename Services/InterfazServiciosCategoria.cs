using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Categoria"

 */

namespace TruequeTools.Services
{
    public interface InterfazServiciosCategoria
    {
        public Task<List<Categoria>> ReadAllCategorias(); //Read
    }

}
