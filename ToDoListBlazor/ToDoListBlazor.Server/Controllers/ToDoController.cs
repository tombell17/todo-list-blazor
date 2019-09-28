using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Exceptions;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        
        private readonly IRepository<ToDo> _toDoRepository;

        public ToDoController(IRepository<ToDo> toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(ToDo newToDo)
        {
            try
            {
                var createdToDo = await _toDoRepository.Create(newToDo);

                return Ok(createdToDo);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _toDoRepository.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Put(ToDo todo)
        {
            try
            {
                return Json(await _toDoRepository.Update(todo));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();                
            }                  
        }
    }
}
