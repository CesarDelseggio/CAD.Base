using CAD.Base.Common.ViewModels.Account;
using System.Threading.Tasks;

namespace CAD.Base.Web.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginUser user);
        Task<bool> Register(RegisterUser user);
        Task<LoginResponse> RefreshToken(string refreshToken);
    }
}
