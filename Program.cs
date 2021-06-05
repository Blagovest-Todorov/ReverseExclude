using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ReverseExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var divisibleNumber = int.Parse(Console.ReadLine());
            Predicate<int>filter = number => number % divisibleNumber != 0;
            Action<int[]> printer = numbers => Console.WriteLine(string.Join(" ", numbers.Reverse()
                .Where(x => filter(x))));
            printer(numbers);
        }
    }
}
