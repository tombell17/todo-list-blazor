using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> Get(string userId);
    }
}
