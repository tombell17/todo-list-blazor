using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListBlazor.Shared;

namespace ToDoListBlazor.Infrastructure
{
    public class EFDbContext : IdentityDbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) 
               : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
