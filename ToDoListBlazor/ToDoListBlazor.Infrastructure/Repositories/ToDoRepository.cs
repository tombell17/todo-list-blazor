using System.Collections.Generic;
using System.Linq;
using ToDoListBlazor.Domain;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Infrastructure
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
            _count++;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _todos.Where(x => x != null).ToList();
        }
    }
}
