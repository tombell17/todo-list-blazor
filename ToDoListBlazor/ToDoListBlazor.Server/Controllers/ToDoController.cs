using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Exceptions;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(ToDoViewModel newToDo)
        {
            ToDoViewModel createdToDo = await _toDoService.Create(newToDo);

            return Ok(createdToDo);
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
    }
}
