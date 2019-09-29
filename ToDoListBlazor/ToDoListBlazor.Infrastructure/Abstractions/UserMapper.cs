using Microsoft.AspNetCore.Identity;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Infrastructure.Abstractions
{
    public class UserMapper : IUserMapper
    {
        public IdentityUser MapIdentityUser(RegisterRequest request)
        {
            return new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
                NormalizedUserName = request.Name
            };
        }
    }
}
