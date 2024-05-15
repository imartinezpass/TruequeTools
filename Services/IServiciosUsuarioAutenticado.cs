using TruequeTools.Entities;

/*
 
Sirve para los servicios relacionados con la autenticacion (seguramente se borre ya que existen los claims)

 */

namespace TruequeTools.Services
{
    public interface IServiciosUsuarioAutenticado
    {
        public Task InitializeAsync();
        public void RemoveCurrent();
    }
}
