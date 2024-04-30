using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Usuario"

 */

namespace TruequeTools.Services
{
    public interface InterfazServiciosUsuario
    {
        public Task RegisterUsuario(Usuario usuario); //Create
        public Task<bool> SeEncuentraRegistrado(string email); //Read
    }
}
