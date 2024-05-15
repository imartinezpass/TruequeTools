using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Usuario"

 */

namespace TruequeTools.Services
{
    public interface IServiciosUsuario
    {
        public Task RegisterUsuario(Usuario usuario);
        public Task<bool> SeEncuentraRegistrado(string email);
    }
}
