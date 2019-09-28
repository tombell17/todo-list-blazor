using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserAccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RegisterRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new Result
                    {
                        Successful = false,
                        Errors = result.Errors.Select(x => x.Description)
                    });
                }

                return Ok(new Result
                {
                    Successful = true
                });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
    }
}
