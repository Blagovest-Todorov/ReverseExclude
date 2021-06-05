using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> persons = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);

                if (data.Length != 2)
                {
                    continue;
                }

                if (!persons.ContainsKey(name))
                {
                    persons.Add(name, age);
                }
            }

            string condFilter = Console.ReadLine();      //Condition - "younger" or "older"
            int ageFilter = int.Parse(Console.ReadLine()); // Age - Integer
            string printFormat = Console.ReadLine(); //Format - "name", "age" or "name age"

            if (printFormat == "name")
            {
                persons = ReFillDictionary(persons, condFilter, ageFilter);               
            }
            else if (printFormat == "name age")
            {               
                persons = ReFillDictionary(persons, condFilter, ageFilter);                
            }
            else if (printFormat == "age")
            {
                persons = ReFillDictionary(persons, condFilter, ageFilter);                
            }

            PrintDictionary(persons, printFormat);
        }

        private static Dictionary <string, int >ReFillDictionary(
            Dictionary<string, int> persons, string condFilter, int ageFilter)
        {
            if (condFilter == "older")
            {
               persons = persons.Where(p => p.Value >= ageFilter)
                    .ToDictionary(k => k.Key, v => v.Value);                
            }
            else if (condFilter == "younger")
            {
                persons = persons = persons.Where(p => p.Value < ageFilter)
                    .ToDictionary(k => k.Key, v => v.Value);
            }

            return persons;
        }

        private static void PrintDictionary(Dictionary<string, int> persons,
            string printFormat)
        {
            if (persons.Count != 0)
            {
                if (printFormat == "name")
                {
                    foreach (var item in persons)
                    {
                        Console.WriteLine(item.Key);
                    }
                }
                else if (printFormat == "age")
                {
                    foreach (var item in persons)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
                else if (printFormat == "name age")
                {
                    foreach (var item in persons)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
