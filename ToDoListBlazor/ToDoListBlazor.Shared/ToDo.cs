using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListBlazor.Shared
{
    public class ToDo
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(32)]
        public string Title { get; set; }       
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public Priority Priority { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FinishedDateTime { get; set; }
        public bool IsFinished { get; set; }
    }
}
