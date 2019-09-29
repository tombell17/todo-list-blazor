using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IUserAccountService
    {
        Task<Result> RegisterAccount(RegisterRequest request);
    }
}
