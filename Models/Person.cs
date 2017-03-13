namespace Source.Models
{
    public abstract class Person
    {
        public int Age { get; set; }

        public abstract void DisplayAge();
    }
}