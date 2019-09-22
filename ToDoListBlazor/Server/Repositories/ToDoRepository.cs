using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListBlazor.Server.Abstractions;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Server.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDo[] _todos;
        private int _count;

        public ToDoRepository()
        {
            _todos = new ToDo[128];
            _count = 0;
        }

        public void Create(ToDo toDo)
        {
            toDo.Id = _count;
            _todos[_count] = toDo;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _todos.ToList();
        }
    }
}
