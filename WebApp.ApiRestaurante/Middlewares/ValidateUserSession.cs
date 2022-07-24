using Microsoft.AspNetCore.Http;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.Helpers;
using ApiRestaurante.Core.Application.ViewModels.User;

namespace WebApp.ApiRestaurante.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
