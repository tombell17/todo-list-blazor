using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.UserAccount;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IUserMapper
    {
        User Map(RegisterRequest request);
        User Map(UserViewModel userViewModel);
        UserViewModel Map(User user);
    }
}
