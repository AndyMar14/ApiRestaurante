using ApiRestaurante.Core.Application.Dtos.Account;
using StockApp.Core.Application.Dtos.Account;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);
        Task<RegisterResponse> RegisterAdminUserAsync(RegisterRequest request, string origin);
        Task SignOutAsync();
    }
}