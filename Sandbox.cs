using System;
using System.Collections.Generic;
using Source.Models;

namespace Source
{
    public class Sandbox
    {
        public void Run()
        {
            Console.WriteLine("Test mode");
            try
            {
                User user = null;
                var argumentNullException = new ArgumentNullException(nameof(user), "Null argument.");
                throw new ArgumentException("Invalid argument.", argumentNullException);
                throw new Exception("An error occured.");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine($"Argument error\n{exception.Message}\n{exception.InnerException.Message}");
                Console.WriteLine(exception.StackTrace);

                throw;
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Error\n{exception.Message}");
            }
            finally
            {
                Console.WriteLine("Finally.");
            }
        }

        public void Generics()
        {
            var numbersPair = new Pair<User, int>();
            // numbersPair.First = 1;
            numbersPair.Second = 3;     

            var numbersTriple = new Triple<User, int, int>();
            // numbersTriple.First = 1;
            numbersTriple.Second = 3; 
            numbersTriple.Third = 5;    

            DisplayType(5);
            // DisplayType<User>(new User());  
            ProcessOrder(new Order(1));
        }

        public void ProcessOrder<T>(T value) where T : Order
        {
        } 

        public void DisplayType<T>(T value)
        {
            var user = value as User;
            if(user != null)
            {

            }
        }    
    }

    public class Pair<TFirst,TSecond> where TFirst : class where TSecond : struct
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
    }

    public class Triple<TFirst,TSecond,TThird> : Pair<TFirst,TSecond> where TFirst : class where TSecond : struct
    {
        public TThird Third { get; set; }
    }

    public class FixedTriple<TThird> : Pair<Order, int>
    {
        public TThird Third { get; set; }
    }
}