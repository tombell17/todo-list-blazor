using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using ToDoListBlazor.Domain.Abstractions;

namespace ToDoListBlazor.Domain.Entities
{
    public class User : IdentityUser, IEntity
    {
        public int EntityId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ToDo> CreatedToDos { get; set; }
        public IEnumerable<ToDo> AssignedToDos { get; set; }
    }
}
