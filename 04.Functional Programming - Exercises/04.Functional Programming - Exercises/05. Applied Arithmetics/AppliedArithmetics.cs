using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace _05._Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            Action<List<int>> printAction = x => Console.WriteLine(string.Join(" ", x));

            var numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();


            var line = string.Empty;
            while ((line = Console.ReadLine()) != "end")
            {
                switch (line)
                {
                    case "add":
                        numbers = ForEach(numbers, n => n + 1);
                        break;

                    case "subtract":
                        numbers = ForEach(numbers, n => n - 1);
                        break;

                    case "multiply":
                        numbers = ForEach(numbers, n => n * 2);
                        break;

                    case "print":
                        printAction(numbers);
                        break;
                }
            }
        }
        public static List<int> ForEach(List<int> collection, Func<int, int> func)
        {
            return collection.Select(n => func(n)).ToList();
        }

    }
}
