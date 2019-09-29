using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.UserAccount;
using ToDoListBlazor.Domain.Shared.ViewModels;
using ToDoListBlazor.Domain.Abstractions;

namespace ToDoListBlazor.Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User Map(RegisterRequest request)
        {
            return new User
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name
            };
        }     

        public UserViewModel Map(User user)
        {
            return new UserViewModel
            {
                Id = user.EntityId,
                Email = user.Email,
                Name = user.Name,
                UserAccountId = user.Id
            };
        }

        public User Map(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.UserAccountId,                
                Email = userViewModel.Email,
                EntityId = userViewModel.Id,
                Name = userViewModel.Name                
            };
        }
    }
}
