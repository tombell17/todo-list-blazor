﻿using Microsoft.AspNetCore.Mvc;
using ToDoListBlazor.Server.Abstractions;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpPost]
        public ActionResult Post(ToDo newToDo)
        {
            _toDoRepository.Create(newToDo);

            return Json("{}");
        }        
    }
}
