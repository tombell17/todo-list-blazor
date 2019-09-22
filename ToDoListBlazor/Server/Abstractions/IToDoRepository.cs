using System.Collections.Generic;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Server.Abstractions
{
    public interface IToDoRepository
    {
        void Create(ToDo toDo);
        IEnumerable<ToDo> GetAll();
    }
}
