using System.Collections.Generic;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Domain
{
    public interface IToDoRepository
    {
        void Create(ToDo toDo);
        IEnumerable<ToDo> GetAll();
    }
}
