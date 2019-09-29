using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserMapper _userMapper;

        public UserAccountService(UserManager<User> userManager, IUserMapper userMapper)
        {
            _userManager = userManager;
            _userMapper = userMapper;
        }

        public async Task<Result> RegisterAccount(RegisterRequest request)
        {            
            User newUser = _userMapper.Map(request);

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, request.Password);                        

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
