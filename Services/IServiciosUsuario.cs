using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Usuario"

 */

namespace TruequeTools.Services
{
    public interface IServiciosUsuario
    {
        public Task RegisterUsuario(Usuario usuario);
        public Task<Usuario> ReadUsuarioById(int userId);
        public Task<bool> SeEncuentraRegistrado(string email);
        public Task<List<Usuario>> ReadAllEmpleados();
        public Task<List<Usuario>> ReadAllNotDeletedEmpleados();
        public Task<Usuario> OverwriteUsuarioById(Usuario usuario);
        public Task<Usuario> FindEmpleado(int userId);
        public Task RestablecerContraseña(string email);
    }
}
