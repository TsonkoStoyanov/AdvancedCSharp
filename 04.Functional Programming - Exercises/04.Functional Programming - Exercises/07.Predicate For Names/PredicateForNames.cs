using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var targetLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split().ToList();

            Print(names, n => n.Length <= targetLength);
        }

        public static void Print(List<string> collection, Func<string, bool> Filter)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection.Where(Filter)));
        }
    }
}
