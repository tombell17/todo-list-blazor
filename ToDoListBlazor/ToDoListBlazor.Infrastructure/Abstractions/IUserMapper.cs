using Microsoft.AspNetCore.Identity;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Infrastructure.Abstractions
{
    public interface IUserMapper
    {
        IdentityUser MapIdentityUser(RegisterRequest request);
    }
}
