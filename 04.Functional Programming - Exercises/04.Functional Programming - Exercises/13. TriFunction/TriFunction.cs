using System;
using System.Linq;

namespace _13._TriFunction
{
    class TriFunction
    {
        static void Main()
        {
            var targetCharactersSum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int, bool> isValid = (str, num) => str.ToCharArray()
             .Select(ch => (int)ch).Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, num, func) => arr
                .FirstOrDefault(str => func(str, num));

            var result = firstValidName(names, targetCharactersSum, isValid);
            Console.WriteLine(result);
        }
    }
}
