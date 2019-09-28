using System;

namespace ToDoListBlazor.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Entity not found on the DB!")
        {

        }
    }
}
