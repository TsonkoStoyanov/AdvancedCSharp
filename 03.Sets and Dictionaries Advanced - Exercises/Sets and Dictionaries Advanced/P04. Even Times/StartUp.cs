using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Even_Times
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }

                numbers[num]++;
            }

            int result = 0;

            foreach (var number in numbers)
            {
                if (number.Value % 2 == 0)
                {
                    result = number.Key;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
