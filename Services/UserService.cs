using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TruequeTools.Services
{
    public class UserService

    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        ClaimsPrincipal? _current = null;

        public UserService(AuthenticationStateProvider authenticationStateProvider)

        {
            _authenticationStateProvider = authenticationStateProvider;
        }


        public ClaimsPrincipal Current

        {
            get
            {
                if (_current == null) throw new Exception("No user is logged in"); return _current;
            }
        }

        public async Task InitializeAsync()

        {
            if (_current != null)
                return;
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            _current = authState.User;
        }

    }
}
