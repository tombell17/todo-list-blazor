using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IRepository<User> userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            IEnumerable<User> users = await _userRepository.GetAll();            
            return users.Select(user => _userMapper.Map(user));
        }
    }
}
