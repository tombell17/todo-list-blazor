using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Domain.Shared.UserAccount;
using ToDoListBlazor.Infrastructure.Abstractions;

namespace ToDoListBlazor.Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserMapper _userMapper;
        private readonly IRepository<User> _userRepository;

        public UserAccountService(UserManager<IdentityUser> userManager, IUserMapper userMapper, IRepository<User> userRepository)
        {
            _userManager = userManager;
            _userMapper = userMapper;
            _userRepository = userRepository;
        }

        public async Task<Result> RegisterAccount(RegisterRequest request)
        {
            IdentityUser identityUser = _userMapper.MapIdentityUser(request);

            IdentityResult identityResult = await _userManager.CreateAsync(identityUser, request.Password);

            User user = _userMapper.MapUser(identityUser);

            await _userRepository.Create(user);

            return GenerateResult(identityResult);
        }       

        private Result GenerateResult(IdentityResult identityResult)
        {
            return new Result
            {
                Successful = identityResult.Succeeded,
                Errors = identityResult.Succeeded ? null : identityResult.Errors.Select(x => x.Description)
            };
        }
    }
}
