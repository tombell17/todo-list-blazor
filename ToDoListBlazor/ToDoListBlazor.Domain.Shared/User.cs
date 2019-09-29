using Microsoft.AspNetCore.Identity;
using ToDoListBlazor.Domain.Shared.Abstractions;

namespace ToDoListBlazor.Domain.Shared
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
