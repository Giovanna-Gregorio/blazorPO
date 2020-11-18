using System.Threading.Tasks;
using BlazorPO.Shared;

namespace BlazorPO.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}