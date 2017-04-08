namespace Source.Models
{
    public abstract class Entity
    {
        public int Id { get; }

        protected Entity(int id)
        {
            id.FailIfLessThanOne(nameof(id));  
            Id = id;
        }
    }
}