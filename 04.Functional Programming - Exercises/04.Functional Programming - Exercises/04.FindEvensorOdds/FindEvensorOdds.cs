using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensorOdds
{
    class FindEvensorOdds
    {
        static void Main()
        {
            Func<int, bool> evenFunc = x => x % 2 == 0;

            var boundries = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            var type = Console.ReadLine();

            var start = boundries[0];
            var end = boundries[1];
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();


            for (int i = start; i <= end; i++)
            {
                if (evenFunc(i))
                {
                    evenNumbers.Add(i);
                }
                else
                {
                    oddNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", type == "odd" ? oddNumbers : evenNumbers));

        }
    }
}
