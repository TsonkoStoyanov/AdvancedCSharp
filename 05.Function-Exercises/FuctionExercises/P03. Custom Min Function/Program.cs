using System;
using System.Linq;

namespace P03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunc = x => x.Min();

            var nums = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(nums));
        }
    }
}
