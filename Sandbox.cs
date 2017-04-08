using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Source.Models;

namespace Source
{
    public class Sandbox
    {
        public delegate void ShowText(string text);
        public delegate int Adder(int a, int b);
        public delegate void Alert(int temperature);

        public void Run()
        {
            Console.WriteLine("Test mode");
            var products = GetProducts();
            var products2 = products.Where(p => p.Price > 400)
                .Where(p => p.Id > 2)
                .OrderBy(p => p.Name)
                .Skip(2)
                .Take(3)
                .Select(p => new {p.Id, p.Name});
            var ball = products.FirstOrDefault(p => p.Name == "Ball");
            var ball2 = products2.Single(p => p.Name == "Ball");
            var totalPrice = products.Sum(p => p.Price);
        }

        public IEnumerable<Product> GetProducts()
        {
            yield return new Product(1, "Ball", 50);
            yield return new Product(2, "Bicycle", 800);
            yield return new Product(3, "Shoes", 300);
            yield return new Product(4, "Hammer", 150);
            yield return new Product(5, "Keyboard", 200);
            yield return new Product(6, "Laptop", 3000);
        }

        public void Enumerable()
        {
            var numbers = new List<int>
            {
                1,2,3,4,5
            };
            IEnumerable<int> numbers2 = GetNumbers(5);
            foreach(var number in numbers2)
            {
                Console.WriteLine(numbers);
            }
            
            var enumerator = numbers2.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var number = enumerator.Current;
            }
        }

        public IEnumerable<int> GetNumbers(int range)
        {
            for(var i=0; i<range; i++)
            {
                yield return i;
            }
            // yield return 1;
            // yield return 2;
            // yield return 3;
            // yield return 4;
            // yield return 5;
        }

        public void Delegates()
        {
            ShowText showText = DisplayText;
            showText("Hello");
            Adder adder = Add;
            var result = adder(1,2);
            CheckTemperature(TooHotAlert, OptimalAlert, TooLowAlert);

            ShowText showText2 = text => Console.WriteLine(text);
            Adder adder2 = (a,b) => a+b;

            Action displayText = () => {};
            Action<string> showText3 = text => Console.WriteLine(text);

            Func<int> getNumber = () => 1;
            Func<int,int,int> adder3 = (a,b) => a+b;
            Action<string> log = text => Console.WriteLine(text);
            
            CheckTemperature(t => log($"Too hot! {t} C"),
            t => log($"Optimal. {t} C"),
            t => log($"Too cold! {t} C"));
        }

        public void TooHotAlert(int temperature)
        {
            Console.WriteLine($"Too hot! {temperature} C");
        }

        public void OptimalAlert(int temperature)
        {
            Console.WriteLine($"Optimal. {temperature} C");
        }

        public void TooLowAlert(int temperature)
        {
            Console.WriteLine($"Too cold! {temperature} C");
        }

        public void CheckTemperature(Action<int> tooHot, Action<int> optimal, Action<int> tooLow)
        {
            var random = new Random();
            var temperature = 20;
            while(true)
            {
                var difference = random.Next(-5,5);
                temperature+=difference;
                if(temperature > 25)
                {
                    tooHot(temperature);
                }
                else if(temperature <= 25 && temperature >= 15)
                {
                    optimal(temperature);
                }
                else
                {
                    tooLow(temperature);
                }
                Thread.Sleep(500);
            }
        }

        public int Add(int a, int b)
            => a+b;

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public void Exceptions()
        {
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