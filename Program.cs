using System;

namespace Source
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Available commands: app, test");
            var input = string.Empty;
            while(input != "q")
            {
                Console.Write("> ");
                input = Console.ReadLine();
                switch(input)
                {
                    case "app": 
                        Shop shop = new Shop();
                        shop.BuyStuff();
                        break;

                    case "test":
                        new Sandbox().Run();
                        break;

                    case "q":
                        Console.WriteLine("Bye!");
                        break;                    

                    default: 
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }

        }
    }
}
