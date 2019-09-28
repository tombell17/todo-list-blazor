using System.Collections.Generic;

namespace ToDoListBlazor.Domain.Shared.UserAccount
{
    public class Result
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
