using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;

namespace ToDoListBlazor.Server.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _userService.GetAll());
        }
    }
}
