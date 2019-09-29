using Microsoft.AspNetCore.Identity;
using ToDoListBlazor.Domain.Shared;
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

        public User MapUser(IdentityUser identityUser)
        {
            return new User
            {
                Email = identityUser.Email,
                Name = identityUser.NormalizedUserName,
                IdentityUser = identityUser
            };
        }
    }
}
