using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.UserAccount;
using ToDoListBlazor.Infrastructure.Abstractions;

namespace ToDoListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserMapper _userMapper;

        public UserAccountController(UserManager<IdentityUser> userManager, IUserMapper userMapper)
        {
            _userManager = userManager;
            _userMapper = userMapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RegisterRequest request)
        {
            var user = _userMapper.MapIdentityUser(request);

            var identityResult = await _userManager.CreateAsync(user, request.Password);

            if (identityResult.Succeeded)
            {
                return Ok(new Result { Successful = true });
            }

            return BadRequest(GenerateBadRequestResult(identityResult));            
        }   
        
        private Result GenerateBadRequestResult(IdentityResult identityResult)
        {
            return new Result
            {
                Successful = false,
                Errors = identityResult.Errors.Select(x => x.Description)
            };
        }
    }
}
