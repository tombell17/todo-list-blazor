using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IToDoService
    {
        Task<ToDoViewModel> Create(ToDoViewModel toDoViewModel);
        Task<ToDoViewModel> Update(ToDoViewModel toDoViewModel);
        Task Delete(ToDoViewModel toDoViewModel);
        Task<ToDoViewModel> Get(int id);
        Task<IEnumerable<ToDoViewModel>> GetAll();
    }
}
