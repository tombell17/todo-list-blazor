using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Exceptions;
using ToDoListBlazor.Domain.Shared.ViewModels;
using ToDoListBlazor.Server.SignalR;

namespace ToDoListBlazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IHubContext<ToDoHub> _hubContext;
        private readonly IUserService _userService;

        public ToDoController(IToDoService toDoService, IHubContext<ToDoHub> hubContext, IUserService userService)
        {
            _toDoService = toDoService;
            _hubContext = hubContext;
            _userService = userService;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(ToDoViewModel newToDo)
        {
            try
            {
                ToDoViewModel createdToDo = await _toDoService.Create(newToDo);

                await PushToDoToAssignedUser(createdToDo);

                return Ok(createdToDo);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _toDoService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Put(ToDoViewModel todo)
        {
            try
            {
                return Json(await _toDoService.Update(todo));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();                
            }                  
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ToDoViewModel todo)
        {
            await _toDoService.Delete(todo);
            return Ok();
        }      
        
        private async Task PushToDoToAssignedUser(ToDoViewModel toDoViewModel)
        {
            if(toDoViewModel.CreatedByUserId != toDoViewModel.AssignedtoUserId)
            {
                UserViewModel user = await _userService.Get(toDoViewModel.AssignedtoUserId);
                await ToDoHub.PushToDo(toDoViewModel, user.Email, _hubContext);
            }            
        }
    }
}
