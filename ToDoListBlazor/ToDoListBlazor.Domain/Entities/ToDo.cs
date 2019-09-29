using System;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Shared;

namespace ToDoListBlazor.Domain.Entities
{
    public class ToDo : IEntity
    {
        public int EntityId { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }       
        public Priority Priority { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FinishedDateTime { get; set; }
        public bool IsFinished { get; set; }
        public string CreatedByUserId { get; set; }
        public string AssignedtoUserId { get; set; }
        public User CreatedBy { get; set; }
        public User AssignedTo { get; set; }
    }
}
