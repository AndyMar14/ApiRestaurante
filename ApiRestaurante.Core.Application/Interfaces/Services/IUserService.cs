using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task SignOutAsync();
    }
}