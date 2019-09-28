using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Client.Services
{
    public interface IAuthService
    {
        Task<Result> Register(RegisterRequest request);
        Task<LoginResult> Login(LoginRequest request);
        Task Logout();
    }
}
