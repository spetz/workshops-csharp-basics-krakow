using System;

namespace Source
{
    public static class Extensions
    {
        public static bool IsEmpty(this string value, string type)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"Invalid {type}");
                return true;
            }
            return false;
        }        
    }
}