using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly IToDoMapper _todoMapper;

        public ToDoService(IRepository<ToDo> toDoRepository, IToDoMapper todoMapper)
        {
            _toDoRepository = toDoRepository;
            _todoMapper = todoMapper;
        }

        public async Task<ToDoViewModel> Create(ToDoViewModel toDoViewModel)
        {
            ToDo toDo = _todoMapper.Map(toDoViewModel);
            await _toDoRepository.Create(toDo);
            return _todoMapper.Map(toDo);            
        }

        public async Task Delete(ToDoViewModel toDoViewModel)
        {
            ToDo toDo = _todoMapper.Map(toDoViewModel);
            await _toDoRepository.Delete(toDo);
        }

        public async Task<ToDoViewModel> Get(int id)
        {
            ToDo toDo = await _toDoRepository.Get(id);
            return _todoMapper.Map(toDo);
        }

        public async Task<IEnumerable<ToDoViewModel>> GetAll()
        {
            IEnumerable<ToDo> toDos = await _toDoRepository.GetAll();
            return toDos.Select(toDo => _todoMapper.Map(toDo));
        }

        public async Task<ToDoViewModel> Update(ToDoViewModel toDoViewModel)
        {
            ToDo toDo = _todoMapper.Map(toDoViewModel);
            await _toDoRepository.Update(toDo);
            return _todoMapper.Map(toDo);
        }
    }
}
