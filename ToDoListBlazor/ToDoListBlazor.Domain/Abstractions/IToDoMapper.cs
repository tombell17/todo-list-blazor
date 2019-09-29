using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IToDoMapper
    {
        ToDoViewModel Map(ToDo toDo);
        ToDo Map(ToDoViewModel toDo);
    }
}
