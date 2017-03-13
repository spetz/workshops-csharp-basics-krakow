using System;

namespace Source.Models
{
    public interface IEmailSender
    {
         void Send(string sender, string receiver, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void Send(string sender, string receiver, string message)
        {
            Console.WriteLine($"{sender} {receiver} {message}");
        }
    }

    public interface IDatabase
    {
        void Connect();
        void SaveChanges();
    }

    public class Database : IDatabase
    {
        public void Connect()
        {
            Console.WriteLine("Connected to database.");
        }

        public void SaveChanges()
        {
            Console.WriteLine("Saved changes in database.");
        }
    }

    public class FakeDatabase : IDatabase
    {
        public void Connect()
        {
            Console.WriteLine("Connected to fake database.");
        }

        public void SaveChanges()
        {
            Console.WriteLine("Saved changes in a fake database.");
        }
    }

    public interface IUserService
    {
        User Register(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailSender;

        public UserService(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }

        public User Register(string email, string password)
        {
            User user = new User(email, password);
            _database.Connect();
            _database.SaveChanges();
            _emailSender.Send(email, "system@email.com", "Welcome!");

            return user;
        }
    }
}