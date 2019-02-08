using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Sets_of_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < input[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                n.Add(num);
            }

            for (int i = 0; i < input[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                m.Add(num);
            }

            foreach (var item in n)
            {
                if (m.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
