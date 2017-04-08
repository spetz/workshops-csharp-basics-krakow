using System;
using System.Collections.Generic;
using System.Linq;
using Source.Models;

namespace Source
{
    public static class Extensions
    {
        public static bool Empty(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static void FailIfEmpty(this string value, string paramName)
        {
            if(value.Empty())
            {
                throw new ArgumentException($"{paramName} is not specified.", paramName);
            }
        }

        public static void FailIfLessThanOne(this int value, string paramName)
            => value.FailIfLessThan(1, paramName);

        public static void FailIfLessThan(this int value, int threshold, string paramName)
        {
            if(value < threshold)
            {
                throw new ArgumentException($"{paramName} is less than {threshold}.", paramName);
            }
        }

        public static void FailIfLessThanZero(this decimal value, string paramName)
        {
            if(value < 0)
            {
                throw new ArgumentException($"{paramName} is less than 0.", paramName);
            }
        }

        public static T GetById<T>(this IEnumerable<T> values, int id) where T : Entity
            => values.SingleOrDefault(x => x.Id == id);
    }
}