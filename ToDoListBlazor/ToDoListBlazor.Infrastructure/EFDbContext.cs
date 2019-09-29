using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListBlazor.Domain.Entities;

namespace ToDoListBlazor.Infrastructure
{
    public class EFDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) 
               : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            

            modelBuilder.Entity<ToDo>()
                        .HasKey(toDo => toDo.EntityId)
                        .HasName("Id");

            modelBuilder.Entity<ToDo>()
                        .HasOne(toDo => toDo.CreatedBy)
                        .WithMany(user => user.CreatedToDos)
                        .HasForeignKey(x => x.CreatedByUserId);
            
            modelBuilder.Entity<ToDo>()
                        .HasOne(toDo => toDo.AssignedTo)
                        .WithMany(user => user.AssignedToDos)
                        .HasForeignKey(x => x.AssignedtoUserId);
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> User { get; set; }
    }
}
