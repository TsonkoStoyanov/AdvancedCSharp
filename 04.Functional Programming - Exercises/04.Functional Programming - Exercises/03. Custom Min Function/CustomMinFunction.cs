using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main()
        {
            Func<int[], int> minFunc = x => x.Min();

            var nums = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(nums));
        }
    }
}
