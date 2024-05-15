using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosUsuarioAutenticado"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Se creó por desconocimiento de los claims provistos por la autenticacion. Seguramente sea borrada.
 
 */

namespace TruequeTools.Services
{
    public class ServiciosUsuarioAutentificado(AuthenticationStateProvider authenticationStateProvider) : IServiciosUsuarioAutenticado
    {

        private readonly AuthenticationStateProvider _authenticationStateProvider = authenticationStateProvider;
        ClaimsPrincipal? _current = null;

        public ClaimsPrincipal Current { get {if (_current == null) throw new Exception("No user is logged in"); return _current;} }

        public async Task InitializeAsync()
        {
            if (_current != null)
            {
                return;
            }
            else
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                _current = authState.User;
            }     
        }

        public void RemoveCurrent()
        {
            _current = null;
        }

    }

}
