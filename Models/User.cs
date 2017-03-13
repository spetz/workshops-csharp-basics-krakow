using System;

namespace Source.Models
{
    public class User : Person
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Address Address { get; private set; }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if(email.IsEmpty("email"))
            {
                return;
            }
            Email = email;
        }

        public void SetPassword(string password)
        {
            if(password.IsEmpty("password"))
            {
                return;
            }
            Password = password;
        }

        public virtual void SayMyName()
        {
            Console.WriteLine("I'm a user.");
        }

        public override void DisplayAge()
        {
            throw new NotImplementedException();
        }
    }
}