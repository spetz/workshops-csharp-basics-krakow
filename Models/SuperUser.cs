using System;

namespace Source.Models
{
    public class SuperUser : User
    {
        public SuperUser(string email, string password) 
            : base(email, password)
        {
        }

        public override void SayMyName()
        {
            base.SayMyName();
            Console.WriteLine("I'm a super user.");
        }
    }
}