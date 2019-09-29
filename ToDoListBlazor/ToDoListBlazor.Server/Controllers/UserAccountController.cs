using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Shared.UserAccount;

namespace ToDoListBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RegisterRequest request)
        {
            var registrationResult = await _userAccountService.RegisterAccount(request);            

            if (registrationResult.Successful)
            {
                return Ok(registrationResult);
            }

            return BadRequest(registrationResult);            
        }           
        
    }
}
