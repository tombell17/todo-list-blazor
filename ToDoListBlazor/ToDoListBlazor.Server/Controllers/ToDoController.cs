using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Server.Controllers
{
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
        //[Authorize]
        public async Task<ActionResult> Post(ToDo newToDo)
        {
            try
            {
                var createdToDo = await _toDoRepository.Create(newToDo);

                return Ok(createdToDo);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            
        }        

        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<ToDo>> Get()
        {
            return await _toDoRepository.GetAll();
        }
    }
}
