using System;

namespace Source.Models
{
    public abstract class Entity
    {
        public int Id { get; }

        protected Entity(int id)
        {
            //TODO: Add validation.   
            Id = id;
        }
    }
}