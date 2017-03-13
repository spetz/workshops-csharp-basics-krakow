using System;
using System.Collections.Generic;
using Source.Models;

namespace Source
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int x = 1;
            // double money = 20.5;
            // decimal cash = 10.5M;
            // string name = "Piotr";
            // char c = 'c';
            // Console.WriteLine("Hello World!");
            // DisplayText("Text");
            // int sum = Add(1,2, z: 5);
            // string sumResult = $"Result: {sum}";
            // Console.WriteLine(sumResult);
            Test();
        }

        public static int Add(int x, int y, int z = 10)
        {
            int result = x + y + z;

            return x + y + z;
        }

        public static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public static void Test()
        {
            IEmailSender emailSender = new EmailSender();
            IDatabase database = new FakeDatabase();
            IUserService userService = new UserService(database, emailSender);
            User newUser = userService.Register("user@email.com", "secret");


            // Person person = new Person();
            var user = new User("my@email.com", "secret");
            var superUser = new SuperUser("my@email.com", "secret");
            // user.SetEmail("    ");
            user.SayMyName();
            superUser.SayMyName();

            SuperUser realSuperUser = superUser as SuperUser;
            bool isSuperUser = superUser is SuperUser;
            if(realSuperUser != null)
            {
                realSuperUser.Age = 50;
                Console.WriteLine(realSuperUser.Age);
            }            

            var users = new List<User>
            {
                user, superUser
            };
            foreach(User userElement in users)
            {
                userElement.SayMyName();
            }
            // users.Add(user);
            // users.Add(superUser);
        }
    }
}
